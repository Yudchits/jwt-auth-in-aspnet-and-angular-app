using System.Collections.Generic;

namespace JwtAuthentication.DataAccess.Common.Models
{
    public class RoleDb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserRoleDb> UserRoles { get; set; }
    }
}