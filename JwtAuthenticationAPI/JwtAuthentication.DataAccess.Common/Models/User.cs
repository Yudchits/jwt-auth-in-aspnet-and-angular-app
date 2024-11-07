using JwtAuthentication.DataAccess.Common.Helpers;
using System;

namespace JwtAuthentication.DataAccess.Common.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role[] Roles { get; set; }
    }
}