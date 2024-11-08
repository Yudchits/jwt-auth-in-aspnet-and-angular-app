using JwtAuthentication.DataAccess.Common.Helpers;
using JwtAuthentication.DataAccess.Common.Models;
using System;
using System.Threading.Tasks;

namespace JwtAuthentication.DataAccess.Common.Repositories
{
    public interface IUserRepository
    {
        Task<UserDb> GetByIdAsync(Guid id);
        Task<UserDb> GetByEmailAsync(string email);
        Task<Result<UserDb>> RegisterAsync(UserDb user);
        Task<bool> SaveChangesAsync();
    }
}