using System;
using System.Collections.Generic;
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
            var doctorIdOrdinal = reader.GetOrdinal("doctorId");
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
                    reader.GetInt32(doctorIdOrdinal),
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValueCheckNull<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneNumberOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal),
                    getDoctorSpecialties(reader.GetInt32(doctorIdOrdinal)));
            }
            return doctor;
        }

        /// <summary>
        /// Gets the doctor without appointments for the given date and time
        /// </summary>
        /// <param name="dateTimeToGet">The date time to find available doctors for</param>
        /// <returns>Returns the doctors without appointments for the given date and time</returns>
        public static List<Doctor> GetAvailableDoctors(DateTime dateTimeToGet)
        {
            var doctors = new List<Doctor>();
            const string query =
                "select doctors.doctorId, doctors.lastName, doctors.firstName, doctors.dateOfBirth, doctors.gender, doctors.phone, doctors.addressOne, doctors.addressTwo, doctors.city, doctors.state, doctors.zipCode " +
                "from doctors " +
                "where not exists (select appointmentDateTime from appointments where doctors.doctorId = appointments.doctorId and appointments.appointmentDateTime = @dateTimeToGet)";
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@dateTimeToGet", MySqlDbType.DateTime).Value = dateTimeToGet;

            using var reader = command.ExecuteReader();
            var doctorIdOrdinal = reader.GetOrdinal("doctorId");
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
                var doctor = new Doctor(
                    reader.GetInt32(doctorIdOrdinal),
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValueCheckNull<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneNumberOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal),
                    getDoctorSpecialties(reader.GetInt32(doctorIdOrdinal)));
                doctors.Add(doctor);
            }

            return doctors;
        }

        private static List<string> getDoctorSpecialties(int doctorId)
        {
            var specialties = new List<string>();
            const string query =
                "select specialtyName " +
                "from specialty " +
                "where doctorId = @doctorId ";
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@doctorId", MySqlDbType.Int32).Value = doctorId;
            using var reader = command.ExecuteReader();
            var specialtyOrdinal = reader.GetOrdinal("specialtyName");

            while (reader.Read())
            {
                specialties.Add(reader.GetFieldValueCheckNull<string>(specialtyOrdinal));
            }

            return specialties;
        }
    }
}
