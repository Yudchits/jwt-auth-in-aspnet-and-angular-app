using System.Collections.Generic;

namespace JwtAuthentication.Logic.Common.Models
{
    public class RoleBLL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserRoleBLL> UserRoles { get; set; }
    }
}