﻿using MySql.Data.MySqlClient;
using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Accounts;
using CS3230Project.Model.Users;

namespace CS3230Project.DAL.Accounts
{
    /// <summary>
    /// The data access layer for the accounts
    /// </summary>
    public static class AccountsDAL
    {
        /// <summary>
        /// The login for a user
        ///
        /// Precondition:
        ///     userName != null
        ///     AND userName.isEmpty() == false
        ///     AND password != null
        ///     AND password.isEmpty() == false
        /// Postcondition: CurrentUser.User == The logged in user
        /// </summary>
        /// <param name="userName">The username to log in</param>
        /// <param name="password">The password to log in</param>
        public static bool Login(string userName, string password)
        {
            if (userName == null)
            {
                throw new ArgumentException(AccountsErrorMessages.LoginUserNameCannotBeNull);
            }

            if (userName.Trim().Length == 0)
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

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select *" +
                                 "from nurses, accounts " +
                                 "where nurses.employeeID = accounts.employeeID " +
                                 "and exists (" +
                                 "  select userName, `password` " +
                                 "  from accounts " +
                                 "  where userName = @username " +
                                 "  and `password` = @password " +
                                 "  and accounts.employeeID = nurses.employeeID);";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@userName", MySqlDbType.String).Value = userName;
            command.Parameters.Add("@password", MySqlDbType.String).Value = password;

            using var reader = command.ExecuteReader();
            var idOrdinal = reader.GetOrdinal("employeeID");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
            var userNameOrdinal = reader.GetOrdinal("userName");
            var nurseIdOrdinal = reader.GetOrdinal("nurseId");
            var dateOfBirthOrdinal = reader.GetOrdinal("dateOfBirth");
            var genderOrdinal = reader.GetOrdinal("gender");
            var phoneOrdinal = reader.GetOrdinal("phone");
            var addressOneOrdinal = reader.GetOrdinal("addressOne");
            var addressTwoOrdinal = reader.GetOrdinal("addressTwo");
            var cityOrdinal = reader.GetOrdinal("city");
            var stateOrdinal = reader.GetOrdinal("state");
            var zipcodeOrdinal = reader.GetOrdinal("zipcode");

            while (reader.Read())
            {
                CurrentUser.User = new Nurse(
                    reader.GetInt32(nurseIdOrdinal),
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValueCheckNull<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal),
                    reader.GetFieldValueCheckNull<string>(userNameOrdinal));
            }

            return CurrentUser.User != null;
        }
    }
}
