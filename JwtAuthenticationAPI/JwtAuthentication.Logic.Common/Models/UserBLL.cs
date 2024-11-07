using System;
using System.Collections.Generic;

namespace JwtAuthentication.Logic.Common.Models
{
    public class UserBLL
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<UserRolesBLL> UserRoles { get; set; }
    }
}