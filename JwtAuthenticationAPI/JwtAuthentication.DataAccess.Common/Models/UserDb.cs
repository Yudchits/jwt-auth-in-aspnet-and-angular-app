using System;

namespace JwtAuthentication.DataAccess.Common.Models
{
    public class UserDb
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}