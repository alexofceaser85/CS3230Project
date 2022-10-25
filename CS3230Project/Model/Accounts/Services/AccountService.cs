using System;
using System.Security.Cryptography;
using System.Text;
using CS3230Project.DAL.Accounts;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Accounts.Services
{
    /// <summary>
    /// The service layer for the account functions
    /// </summary>
    public static class AccountService
    {
        /// <summary>
        /// Logs a user into the system
        ///
        /// Precondition:
        ///     username != null
        ///     AND username.length == 0
        ///     AND password != null
        ///     AND password.length == 0
        /// Postcondition:
        ///     The user is logged in
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The password</param>
        public static bool Login(string username, string password)
        {
            if (username == null)
            {
                throw new ArgumentException(AccountsErrorMessages.LoginUserNameCannotBeNull);
            }
            if (username.Trim().Length == 0)
            {
                throw new ArgumentException(AccountsErrorMessages.LoginUserNameCannotBeEmpty);
            }
            if (password == null)
            {
                throw new ArgumentException(AccountsErrorMessages.LoginPasswordCannotBeNull);
            }
            if (password.Trim().Length == 0)
            {
                throw new ArgumentException(AccountsErrorMessages.LoginPasswordCannotBeEmpty);
            }

            return AccountsDAL.Login(username, hashPassword(password));
        }

        private static string hashPassword(string passwordToHash)
        {
            using HashAlgorithm algorithm = SHA256.Create();
            var bytes = algorithm.ComputeHash(Encoding.UTF8.GetBytes(passwordToHash));
            var builder = new StringBuilder();
            foreach (var passwordByte in bytes)
            {
                builder.Append(passwordByte.ToString("x2"));
            }
            var hashedPassword = builder.ToString();
            return hashedPassword;
        }
    }
}
