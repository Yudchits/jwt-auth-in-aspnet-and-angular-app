using System;
using System.Collections.Generic;

namespace JwtAuthentication.DataAccess.Common.Models
{
    public class UserDb
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserRoleDb> UserRoles { get; set; }
    }
}