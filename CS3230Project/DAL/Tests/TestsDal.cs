using System.Collections.Generic;
using CS3230Project.Model.Tests;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Tests
{
    /// <summary>
    /// The DAL class for the tests
    /// </summary>
    public static class TestsDal
    {
        /// <summary>
        /// Gets the completed tests for a given appointment
        /// </summary>
        /// <param name="appointmentId">The Id of the appointment to get the tests for</param>
        /// <returns>The tests for the given appointment</returns>
        public static List<PerformedTest> GetCompletedTestsForAppointment(int appointmentId)
        {
            var tests = new List<PerformedTest>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = "call uspGetCompletedTestsForAppointment(@appointmentId);";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            using var reader = command.ExecuteReader();
            var appointmentIdOrdinal = reader.GetOrdinal("appointmentId");
            var testCodeOrdinal = reader.GetOrdinal("testCode");
            var testNameOrdinal = reader.GetOrdinal("name");
            var resultOrdinal = reader.GetOrdinal("results");
            var isAbnormalOrdinal = reader.GetOrdinal("isAbnormal");
            var testDateTimeOrdinal = reader.GetOrdinal("testDateTime");

            while (reader.Read())
            {
                tests.Add(new PerformedTest(
                    reader.GetInt32(appointmentIdOrdinal),
                    reader.GetInt32(testCodeOrdinal),
                    reader.GetString(testNameOrdinal), 
                    reader.GetString(resultOrdinal), 
                    reader.GetBoolean(isAbnormalOrdinal), 
                    reader.GetDateTime(testDateTimeOrdinal)
                ));
            }

            return tests;
        }

        /// <summary>
        /// Gets the non completed tests for a given appointment
        /// </summary>
        /// <param name="appointmentId">The Id of the appointment to get the tests for</param>
        /// <returns>The tests for the given appointment</returns>
        public static List<NotPerformedTest> GetNonCompletedTestsForAppointment(int appointmentId)
        {
            var tests = new List<NotPerformedTest>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = "call uspGetNonCompletedTestsForAppointment(@appointmentId);";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            using var reader = command.ExecuteReader();
            var appointmentIdOrdinal = reader.GetOrdinal("appointmentId");
            var testCodeOrdinal = reader.GetOrdinal("testCode");
            var testNameOrdinal = reader.GetOrdinal("name");

            while (reader.Read())
            {
                tests.Add(new NotPerformedTest(
                    reader.GetInt32(appointmentIdOrdinal),
                    reader.GetInt32(testCodeOrdinal),
                    reader.GetString(testNameOrdinal)
                ));
            }

            return tests;
        }

        /// <summary>
        /// Gets all of the possible tests
        /// </summary>
        /// <returns>The possible tests</returns>
        public static List<AvailableTest> GetPossibleTests(int appointmentId)
        {
            var tests = new List<AvailableTest>();
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = "call uspGetPossibleTests(@appointmentId)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = appointmentId;
            using var reader = command.ExecuteReader();

            var testCodeOrdinal = reader.GetOrdinal("testcode");
            var nameOrdinal = reader.GetOrdinal("name");

            while (reader.Read())
            {
                tests.Add(new AvailableTest(
                    reader.GetInt32(testCodeOrdinal),
                    reader.GetString(nameOrdinal)
                ));
            }

            return tests;
        }

        /// <summary>
        /// Adds a test
        /// </summary>
        /// <param name="testsToAdd">The tests to add</param>
        /// <returns>True if the test was added, false otherwise</returns>
        public static bool AddTests(List<NotPerformedTest> testsToAdd)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            using var command = connection.CreateCommand();
            var transaction = connection.BeginTransaction();
            command.Connection = connection;
            command.Transaction = transaction;

            try
            {
                foreach (var testToAdd in testsToAdd)
                {
                    var query =
                        "insert into visittests values (@appointmentId, @testCode, @results, @isAbnormal, @testDateTime); ";
                    command.CommandText = query;
                    command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = testToAdd.AppointmentId;
                    command.Parameters.Add("@testCode", MySqlDbType.Int32).Value = testToAdd.Code;
                    command.Parameters.Add("@results", MySqlDbType.String).Value = "";
                    command.Parameters.Add("@isAbnormal", MySqlDbType.Int16).Value = false;
                    command.Parameters.Add("@testDateTime", MySqlDbType.DateTime).Value = null;
                    command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }
                transaction.Commit();
                return true;
            }
            catch (MySqlException)
            {
                transaction.Rollback();
                return false;
            }
        }

        /// <summary>
        /// Adds the test results
        /// </summary>
        /// <param name="testResultsToAdd">The test results to add</param>
        /// <returns>True if the results were added, false otherwise</returns>
        public static bool AddTestResults(PerformedTest testResultsToAdd)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query =
                "update visittests set results = @results, isAbnormal = @isAbnormal, testDateTime = @testDateTime where appointmentId = @appointmentId and testCode = @testCode";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@appointmentId", MySqlDbType.Int32).Value = testResultsToAdd.AppointmentId;
            command.Parameters.Add("@testCode", MySqlDbType.Int32).Value = testResultsToAdd.Code;
            command.Parameters.Add("@results", MySqlDbType.String).Value = testResultsToAdd.Results;
            command.Parameters.Add("@isAbnormal", MySqlDbType.Int16).Value = testResultsToAdd.IsAbnormal;
            command.Parameters.Add("@testDateTime", MySqlDbType.DateTime).Value = testResultsToAdd.TestDateTime;
            return command.ExecuteNonQuery() > 0;
        }
    }
}
