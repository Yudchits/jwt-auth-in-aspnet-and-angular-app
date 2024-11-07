using System;

namespace JwtAuthentication.DataAccess.Common.Models
{
    public class UserRoleDb
    {
        public Guid UserId { get; set; }
        public int RoleId { get; set; }
        public virtual UserDb User { get; set; }
        public virtual RoleDb Role { get; set; }
    }
}
