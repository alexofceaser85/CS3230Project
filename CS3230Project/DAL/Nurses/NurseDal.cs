using System;
using System.Collections.Generic;
using CS3230Project.Model.Users;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Nurses
{
    /// <summary>
    ///   The data access layer for the nurses
    /// </summary>
    public static class NurseDal
    {

        /// <summary>
        /// Gets the nurses.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <returns>
        ///   A list of all the nurses
        /// </returns>
        public static List<Nurse> GetNurses()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select * from nurses";
            using var command = new MySqlCommand(query, connection);

            return NurseDal.createNurses(command);
        }

        /// <summary>
        /// Gets the nurse by identifier.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="ID">The identifier.</param>
        /// <returns>
        ///   the nurse with the provided ID
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static Nurse GetNurseByID(int ID)
        {
            Nurse nurse = null;
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select * from nurses where nurseId = @nurseID";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@nurseId", MySqlDbType.String).Value = ID;

            using var reader = command.ExecuteReader();
            var nurseIDOrdinal = reader.GetOrdinal("nurseId");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
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
                nurse = new Nurse(
                    reader.GetInt32(nurseIDOrdinal),
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValueCheckNull<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal));
            }

            return nurse;
        }

        private static List<Nurse> createNurses(MySqlCommand command)
        {
            var nurses = new List<Nurse>();

            using var reader = command.ExecuteReader();
            var nurseIDOrdinal = reader.GetOrdinal("nurseId");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
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
                nurses.Add(new Nurse(
                    reader.GetInt32(nurseIDOrdinal),
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValueCheckNull<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal)));
            }

            return nurses;
        }

    }
}
