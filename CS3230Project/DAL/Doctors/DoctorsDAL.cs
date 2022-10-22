using System;
using CS3230Project.Model.Users;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Doctors
{
    /// <summary>
    /// The data access layer for the doctors
    /// </summary>
    public static class DoctorsDAL
    {
        /// <summary>
        /// Gets the doctor by ID
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="doctorId">The doctor ID</param>
        /// <returns>The doctor with the matching ID</returns>
        public static Doctor GetDoctorById(int doctorId)
        {
            Doctor doctor = null;
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "select *" +
                "from doctors where doctorId = @doctorId";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@doctorId", MySqlDbType.Int32).Value = doctorId;

            using var reader = command.ExecuteReader();
            var patientIdOrdinal = reader.GetOrdinal("doctorId");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var dateOfBirthOrdinal = reader.GetOrdinal("dateOfBirth");
            var genderOrdinal = reader.GetOrdinal("gender");
            var phoneNumberOrdinal = reader.GetOrdinal("phone");
            var addressOneOrdinal = reader.GetOrdinal("addressOne");
            var addressTwoOrdinal = reader.GetOrdinal("addressTwo");
            var cityOrdinal = reader.GetOrdinal("city");
            var stateOrdinal = reader.GetOrdinal("state");
            var zipcodeOrdinal = reader.GetOrdinal("zipcode");

            while (reader.Read())
            {
                doctor = new Doctor(
                    reader.GetInt32(patientIdOrdinal),
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValue<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneNumberOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal));
            }

            return doctor;
        }
    }
}
