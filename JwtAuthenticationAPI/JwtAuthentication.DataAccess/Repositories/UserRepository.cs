using JwtAuthentication.DataAccess.Common.Helpers;
using JwtAuthentication.DataAccess.Common.Models;
using JwtAuthentication.DataAccess.Common.Repositories;
using JwtAuthentication.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace JwtAuthentication.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly JwtAuthenticationContext _context;

        public UserRepository(JwtAuthenticationContext context)
        {
            _context = context;
        }

        public async Task<UserDb> GetByIdAsync(Guid id)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserDb> GetByEmailAsync(string email)
        {
            return await _context.Users
                .Include(u => u.UserRoles)
                .ThenInclude(ur => ur.Role)
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<Result<UserDb>> RegisterAsync(UserDb user)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    await _context.Users.AddAsync(user);
                    var isCreated = await SaveChangesAsync();
                    if (!isCreated)
                    {
                        return Result<UserDb>.Fail("User wasn't created");
                    }

                    var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name == UserRoles.USER);
                    if (role == null)
                    {
                        role = new RoleDb
                        {
                            Name = UserRoles.USER
                        };

                        await _context.Roles.AddAsync(role);
                        var isRoleCreated = await SaveChangesAsync();
                        if (!isRoleCreated)
                        {
                            throw new ArgumentException("There is no user role. Write to admin");
                        }
                    }

                    var userRoles = new UserRoleDb
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    };

                    await _context.UserRoles.AddAsync(userRoles);
                    var isUserRolesCreated = await SaveChangesAsync();
                    if (!isUserRolesCreated)
                    {
                        throw new InvalidOperationException("Role wasn't added to user");
                    }

                    await transaction.CommitAsync();
                    return Result<UserDb>.Ok(user);
                }
                catch (Exception exception)
                {
                    await transaction.RollbackAsync();
                    return Result<UserDb>.Fail(exception.Message);
                }
            }
        }

        public async Task<bool> SaveChangesAsync()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows > 0;
        }
    }
}
