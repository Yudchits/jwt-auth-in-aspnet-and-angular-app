using System;

namespace JwtAuthentication.Logic.Common.Models
{
    public class UserRoleBLL
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public UserBLL User { get; set; }
        public RoleBLL Role { get; set; }
    }
}