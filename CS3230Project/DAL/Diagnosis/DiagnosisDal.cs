using System.Collections.Generic;
using MySql.Data.MySqlClient;

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
        /// Gets the diagnoses.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        ///   The diagnoses with the provided appointment id, if exists.
        /// </returns>
        public static List<Model.Diagnosis.Diagnosis> GetDiagnoses(int appointmentId)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var query = "call uspGetDiagnoses(@appointmentId)";
            using var command = new MySqlCommand(query, connection);
            List<Model.Diagnosis.Diagnosis> diagnoses = new List<Model.Diagnosis.Diagnosis>();

            command.Parameters.Add("@appointmentId", MySqlDbType.Int16).Value = appointmentId;
            using var reader = command.ExecuteReader();
            var diagnosisIdOrdinal = reader.GetOrdinal("diagnosisId");
            var diagnosisDescriptionOrdinal = reader.GetOrdinal("diagnosisDescription");
            var isFinalOrdinal = reader.GetOrdinal("isFinal");
            var basedOnTestResultsOrdinal = reader.GetOrdinal("basedOnTestResults");

            while (reader.Read())
            {
                diagnoses.Add(new Model.Diagnosis.Diagnosis(reader.GetInt16(diagnosisIdOrdinal), appointmentId,
                    reader.GetFieldValueCheckNull<string>(diagnosisDescriptionOrdinal),
                    reader.GetBoolean(isFinalOrdinal),
                    reader.GetBoolean(basedOnTestResultsOrdinal)));
            }

            return diagnoses;
        }

        /// <summary>
        /// Removes the diagnosis with the provided diagnosis ID
        ///
        /// Precondition: none
        /// Post-condition: the diagnosis is removed from the database
        /// </summary>
        /// <param name="diagnosisId">The diagnosis identifier.</param>
        /// <returns>
        ///   True, if the diagnosis is removed
        ///   False, if the diagnosis is not removed
        /// </returns>
        public static bool RemoveDiagnosis(int diagnosisId)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var comm = connection.CreateCommand();
            comm.CommandText = "delete from diagnosis where diagnosisId = @diagnosisId";
            comm.Parameters.Add("@diagnosisId", MySqlDbType.Int16).Value = diagnosisId;

            return comm.ExecuteNonQuery() > 0;
        }

    }
}
