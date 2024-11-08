using JwtAuthentication.Logic.Common.Models;
using System.Text.RegularExpressions;

namespace JwtAuthentication.Logic.Validators
{
    public class UserValidator
    {
        public static bool IsUserValid(UserBLL user, out string errorMessage)
        {
            if (!IsEmailValid(user.Email, out errorMessage))
            {
                return false;
            }

            if (!IsPasswordValid(user.Password, out errorMessage))
            {
                return false;
            }

            errorMessage = null;
            return true;
        }

        private static bool IsEmailValid(string email, out string errorMessage)
        {
            if (string.IsNullOrEmpty(email)) {
                errorMessage = "The email can't be empty";
                return false;
            };


            if (email.Length > 32)
            {
                errorMessage = "The email length can't be more than 32";
                return false;
            }

            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            var isEmail = Regex.IsMatch(email, emailPattern);
            if (!isEmail)
            {
                errorMessage = "Invalid email format";
                return false;
            }

            errorMessage = null;
            return true;
        }

        private static bool IsPasswordValid(string password, out string errorMessage)
        {
            if (string.IsNullOrEmpty(password))
            {
                errorMessage = "The password can't be empty";
                return false;
            }

            if (password.Length > 32)
            {
                errorMessage = "The password length can't be more than 32";
                return false;
            }

            var characters = password.ToCharArray();

            foreach (var character in characters)
            {
                int charCode = character;
                if (charCode < 33 || charCode > 122)
                {
                    errorMessage = "The password contains invalid character";
                }
            }

            errorMessage = null;
            return true;
        }
    }
}
