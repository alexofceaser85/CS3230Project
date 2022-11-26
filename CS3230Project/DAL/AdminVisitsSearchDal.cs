using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using CS3230Project.Model.Tests;
using CS3230Project.Model.Visits;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    ///   The DAL class for the Admin visits search
    /// </summary>
    public static class AdminVisitsSearchDal
    {

        /// <summary>
        /// Gets all visits between dates.
        /// </summary>
        /// <param name="startDate">The start date.</param>
        /// <param name="endDate">The end date.</param>
        /// <returns>
        ///   The admin search visits between the 2 dates
        /// </returns>
        public static List<AdminSearchVisit> GetAllVisitsBetweenDates(DateTime startDate, DateTime endDate)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            const string query = "select appointmentDateTime, appointments.appointmentId, patients.patientId, patients.firstName as patientFirstName, " +
                                 "patients.lastName as patientLastName, doctors.firstName as doctorFirstName, doctors.lastName as doctorLastName, " +
                                 "nurses.firstName as nurseFirstName, nurses.lastName as nurseLastName " +
                                 "from appointments, patients, doctors, visit, nurses " +
                                 "where appointments.patientId = patients.patientId and appointments.doctorId = doctors.doctorId and " +
                                 "appointments.appointmentId = visit.appointmentId and visit.nurseId = nurses.nurseId and " +
                                 "appointmentDateTime >= @startDate and appointmentDateTime <= @endDate " +
                                 "order by appointmentDateTime, patients.lastName";
            using var command = new MySqlCommand(query, connection);
            List<AdminSearchVisit> visits = new List<AdminSearchVisit>();

            command.Parameters.Add("@startDate", MySqlDbType.DateTime).Value = startDate;
            command.Parameters.Add("@endDate", MySqlDbType.DateTime).Value = endDate;
            using var reader = command.ExecuteReader();
            var appointmentDateTimeOrdinal = reader.GetOrdinal("appointmentDateTime");
            var appointmentIdOrdinal = reader.GetOrdinal("appointmentId");
            var patientIdOrdinal = reader.GetOrdinal("patientId");
            var patientFirstNameOrdinal = reader.GetOrdinal("patientFirstName");
            var patientLastNameOrdinal = reader.GetOrdinal("patientLastName");
            var doctorFirstNameOrdinal = reader.GetOrdinal("doctorFirstName");
            var doctorLastNameOrdinal = reader.GetOrdinal("doctorLastName");
            var nurseFirstNameOrdinal = reader.GetOrdinal("nurseFirstName");
            var nurseLastNameOrdinal = reader.GetOrdinal("nurseLastName");

            while (reader.Read())
            {
                visits.Add(new AdminSearchVisit(reader.GetDateTime(appointmentDateTimeOrdinal), reader.GetInt32(appointmentIdOrdinal), reader.GetInt16(patientIdOrdinal), 
                    reader.GetFieldValueCheckNull<string>(patientFirstNameOrdinal), reader.GetFieldValueCheckNull<string>(patientLastNameOrdinal), 
                    reader.GetFieldValueCheckNull<string>(doctorFirstNameOrdinal), reader.GetFieldValueCheckNull<string>(doctorLastNameOrdinal), 
                    reader.GetFieldValueCheckNull<string>(nurseFirstNameOrdinal), reader.GetFieldValueCheckNull<string>(nurseLastNameOrdinal)));

            }

            return visits;
        }

        /// <summary>
        /// Gets all admin search tests for appointment.
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        ///   a list of the admin search tests for an appointment
        /// </returns>
        public static List<AdminSearchTest> GetAllAdminSearchTestsForAppointment(int appointmentId)
        {
            var tests = new List<AdminSearchTest>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = "select name, testDateTime, results, isAbnormal " +
                        "from tests, visittests " +
                        "where tests.testcode = visittests.testCode and appointmentId = @appointmentId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            using var reader = command.ExecuteReader();
            var nameOrdinal = reader.GetOrdinal("name");
            var testDateTimeOrdinal = reader.GetOrdinal("testDateTime");
            var resultsOrdinal = reader.GetOrdinal("results");
            var isAbnormalOrdinal = reader.GetOrdinal("isAbnormal");

            while (reader.Read())
            {
                var date = "";
                try
                { 
                    date = reader.GetDateTime(testDateTimeOrdinal).ToString("MM-dd-yyyy");
                }
                catch (SqlNullValueException)
                {
                    date = "PENDING";
                }

                tests.Add(new AdminSearchTest(reader.GetFieldValueCheckNull<string>(nameOrdinal), date, 
                    reader.GetString(resultsOrdinal), reader.GetBoolean(isAbnormalOrdinal)));
            }

            return tests;
        }

    }
}
