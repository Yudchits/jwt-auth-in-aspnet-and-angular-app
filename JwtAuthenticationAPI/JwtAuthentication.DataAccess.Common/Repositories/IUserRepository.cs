using JwtAuthentication.DataAccess.Common.Helpers;
using JwtAuthentication.DataAccess.Common.Models;
using System;
using System.Threading.Tasks;

namespace JwtAuthentication.DataAccess.Common.Repositories
{
    public interface IUserRepository
    {
        Task<UserDb> GetByIdAsync(Guid id);
        Task<Result<UserDb>> CreateAsync(UserDb user);
        Task<Result<UserDb>> UpdateAsync(UserDb user);
        Task<Result<UserDb>> DeleteAsync(UserDb user);
        Task<bool> SaveChangesAsync();
    }
}