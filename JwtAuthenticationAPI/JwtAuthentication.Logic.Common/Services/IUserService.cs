using JwtAuthentication.DataAccess.Common.Helpers;
using JwtAuthentication.Logic.Common.Models;
using System;
using System.Threading.Tasks;

namespace JwtAuthentication.Logic.Common.Services
{
    public interface IUserService
    {
        Task<UserBLL> GetByIdAsync(Guid id);
        Task<Result<UserBLL>> RegisterAsync(UserBLL user);
        Task<Result<UserBLL>> LoginAsync(UserBLL user);
    }
}