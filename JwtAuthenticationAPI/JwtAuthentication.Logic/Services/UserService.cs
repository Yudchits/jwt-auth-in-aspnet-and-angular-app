using AutoMapper;
using Isopoh.Cryptography.Argon2;
using JwtAuthentication.DataAccess.Common.Helpers;
using JwtAuthentication.DataAccess.Common.Models;
using JwtAuthentication.DataAccess.Common.Repositories;
using JwtAuthentication.Logic.Common.Models;
using JwtAuthentication.Logic.Common.Services;
using JwtAuthentication.Logic.Validators;
using System;
using System.Threading.Tasks;

namespace JwtAuthentication.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserBLL> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id)
                .ContinueWith(result => _mapper.Map<UserBLL>(result.Result));
        }

        public async Task<UserBLL> GetByEmailAsync(string email)
        {
            return await _repository.GetByEmailAsync(email)
                .ContinueWith(result => _mapper.Map<UserBLL>(result.Result));
        }

        public async Task<Result<UserBLL>> CreateAsync(UserBLL user)
        {
            var userByEmail = await _repository.GetByEmailAsync(user.Email);

            if (userByEmail != null)
            {
                return Result<UserBLL>.Fail("The email is already used");
            }

            var isUserValid = UserValidator.IsUserValid(user, out string errorMessage);

            if (!isUserValid)
            {
                return Result<UserBLL>.Fail(errorMessage);
            }

            user.Id = Guid.NewGuid();
            user.Password = Argon2.Hash(user.Password);

            var userDb = _mapper.Map<UserDb>(user);

            var createResult = await _repository.CreateAsync(userDb);
            
            if (!createResult.Success)
            {
                return Result<UserBLL>.Fail(createResult.Message);
            }
            else
            {
                var userBLL = _mapper.Map<UserBLL>(createResult.Data);
                return Result<UserBLL>.Ok(userBLL);
            }
        }

        public Task<Result<UserBLL>> UpdateAsync(UserBLL user)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserBLL>> DeleteAsync(UserBLL user)
        {
            throw new NotImplementedException();
        }

    }
}
