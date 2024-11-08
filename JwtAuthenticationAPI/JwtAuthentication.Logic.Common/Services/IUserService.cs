using JwtAuthentication.DataAccess.Common.Helpers;
using JwtAuthentication.Logic.Common.Models;
using System;
using System.Threading.Tasks;

namespace JwtAuthentication.Logic.Common.Services
{
    public interface IUserService
    {
        Task<UserBLL> GetByIdAsync(Guid id);
        Task<UserBLL> GetByEmailAsync(string email);
        Task<Result<UserBLL>> CreateAsync(UserBLL user);
        Task<Result<UserBLL>> UpdateAsync(UserBLL user);
        Task<Result<UserBLL>> DeleteAsync(UserBLL user);
    }
}