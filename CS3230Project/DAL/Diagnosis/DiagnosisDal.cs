﻿using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Diagnosis
{
    /// <summary>
    ///   The data access layer for the diagnosis
    /// </summary>
    public class DiagnosisDal
    {
        /// <summary>
        /// Adds the diagnosis.
        ///
        /// Precondition: none
        /// Post-condition: the diagnosis provided is added to the database
        /// </summary>
        /// <param name="diagnosisToAdd">The diagnosis to add.</param>
        /// <returns>
        ///   returns true if the diagnosis was added to the database
        ///   returns false if the diagnosis was not added to the database
        /// </returns>
        public static bool AddDiagnosis(Model.Diagnosis.Diagnosis diagnosisToAdd)
        {
            var appointmentId = diagnosisToAdd.AppointmentId;
            var diagnosisDescription = diagnosisToAdd.DiagnosisDescription;
            var isFinal = diagnosisToAdd.IsFinal;
            var basedOnTestResult = diagnosisToAdd.BasedOnTestResults;

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var comm = connection.CreateCommand();
            comm.CommandText = "insert into diagnosis (appointmentId, diagnosisDescription, isFinal, " +
                               "basedOnTestResults) VALUES (@appointmentId, @diagnosisDescription, " +
                               "@isFinal, @basedOnTestResults)";

            comm.Parameters.Add("@appointmentId", MySqlDbType.Int16).Value = appointmentId;
            comm.Parameters.Add("@diagnosisDescription", MySqlDbType.String).Value = diagnosisDescription;
            comm.Parameters.Add("@isFinal", MySqlDbType.Int16).Value = isFinal;
            comm.Parameters.Add("basedOnTestResults", MySqlDbType.Int16).Value = basedOnTestResult;

            return comm.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Modifies the diagnosis.
        ///
        /// Precondition: none
        /// Post-condition: the diagnosis is modified with the provided details
        /// </summary>
        /// <param name="modifiedDiagnosis">The diagnosis to modify.</param>
        /// <returns>
        ///   true if the diagnosis was modified with the provided details
        ///   false if the diagnosis was not modified with the provided details
        /// </returns>
        public static bool ModifyDiagnosis(Model.Diagnosis.Diagnosis modifiedDiagnosis)
        {
            var diagnosisId = modifiedDiagnosis.DiagnosisId;
            var diagnosisDescription = modifiedDiagnosis.DiagnosisDescription;
            var isFinal = modifiedDiagnosis.IsFinal;
            var basedOnTestResult = modifiedDiagnosis.BasedOnTestResults;

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var comm = connection.CreateCommand();
            comm.CommandText =
                "update diagnosis set diagnosisDescription = @diagnosisDescription, isFinal = @isFinal, " +
                "basedOnTestResults = @basedOnTestResults where diagnosisId = @diagnosisId";

            comm.Parameters.Add("@diagnosisId", MySqlDbType.Int16).Value = diagnosisId;
            comm.Parameters.Add("@diagnosisDescription", MySqlDbType.String).Value = diagnosisDescription;
            comm.Parameters.Add("@isFinal", MySqlDbType.Int16).Value = isFinal;
            comm.Parameters.Add("basedOnTestResults", MySqlDbType.Int16).Value = basedOnTestResult;

            return comm.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Gets the diagnosis.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentId">The diagnosis identifier.</param>
        /// <returns>
        ///   The diagnosis with the provided appointment id, if exists.
        /// </returns>
        public static Model.Diagnosis.Diagnosis GetDiagnosis(int appointmentId)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            const string query = "select diagnosisId, diagnosisDescription, isFinal, basedOnTestResults " +
                                 "from diagnosis where appointmentId = @appointmentId";
            using var command = new MySqlCommand(query, connection);

            command.Parameters.Add("@appointmentId", MySqlDbType.Int16).Value = appointmentId;
            using var reader = command.ExecuteReader();
            var diagnosisIdOrdinal = reader.GetOrdinal("diagnosisId");
            var diagnosisDescriptionOrdinal = reader.GetOrdinal("diagnosisDescription");
            var isFinalOrdinal = reader.GetOrdinal("isFinal");
            var basedOnTestResultsOrdinal = reader.GetOrdinal("basedOnTestResults");

            Model.Diagnosis.Diagnosis diagnosis = null;
            while (reader.Read())
            {
                diagnosis = new Model.Diagnosis.Diagnosis(reader.GetInt16(diagnosisIdOrdinal), appointmentId,
                    reader.GetFieldValueCheckNull<string>(diagnosisDescriptionOrdinal),
                    reader.GetBoolean(isFinalOrdinal),
                    reader.GetBoolean(basedOnTestResultsOrdinal));
            }

            return diagnosis;
        }

    }
}
