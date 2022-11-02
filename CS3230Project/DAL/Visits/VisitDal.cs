using System.Runtime.CompilerServices;
using CS3230Project.Model.Appointments;
using CS3230Project.Model.Visits;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Visits
{
    /// <summary>
    ///   The data access layer for the visits
    /// </summary>
    public class VisitDal
    {

        /// <summary>
        /// Adds the visit.
        ///
        /// Precondition: none
        /// </summary>
        /// <param name="visitToAdd">The visit to add.</param>
        /// <returns>
        ///   returns true if the visit was added to the database
        ///   returns false if the visit was not added to the database
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool AddVisit(Visit visitToAdd)
        {
            var appointmentID = visitToAdd.AppointmentID;
            var nurseID = visitToAdd.NurseID;
            var bodyTemp = visitToAdd.BodyTemp;
            var pulse = visitToAdd.Pulse;
            var height = visitToAdd.Height;
            var weight = visitToAdd.Weight;
            var symptoms = visitToAdd.Symptoms;
            var systolicBloodPressure = visitToAdd.SystolicBloodPressure;
            var diastolicBloodPressure = visitToAdd.DiastolicBloodPressure;

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var comm = connection.CreateCommand();
            comm.CommandText = "insert into visit (appointmentId, nurseId, bodyTemp, pulse, height, " +
                               "weight, symptoms, systolicBloodPressure, diastolicBloodPressure) VALUES " +
                               "(@appointmentID, @nurseID, @bodyTemp, @pulse, @height, @weight, @symptoms, " +
                               "@systolicBloodPressure, @diastolicBloodPressure)";

            comm.Parameters.Add("@appointmentID", MySqlDbType.Int16).Value = appointmentID;
            comm.Parameters.Add("@nurseID", MySqlDbType.Int16).Value = nurseID;
            comm.Parameters.Add("@bodyTemp", MySqlDbType.Decimal).Value = bodyTemp;
            comm.Parameters.Add("@pulse", MySqlDbType.Int16).Value = pulse;
            comm.Parameters.Add("@height", MySqlDbType.Decimal).Value = height;
            comm.Parameters.Add("@weight", MySqlDbType.Decimal).Value = weight;
            comm.Parameters.Add("@symptoms", MySqlDbType.String).Value = symptoms;
            comm.Parameters.Add("@systolicBloodPressure", MySqlDbType.Int16).Value = systolicBloodPressure;
            comm.Parameters.Add("@diastolicBloodPressure", MySqlDbType.Int16).Value = diastolicBloodPressure;

            return comm.ExecuteNonQuery() > 0;
        }

        /// <summary>
        /// Gets the visit.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentID">The appointment identifier.</param>
        /// <returns>
        ///   The visit, if exists
        /// </returns>
        public static Visit GetVisit(int appointmentID)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            if (appointmentID >= 0)
            {
                const string query =
                    "select nurseId, bodyTemp, pulse, height, weight, symptoms, systolicBloodPressure, diastolicBloodPressure " +
                    "from visit where @appointmentId = appointmentId";
                using var command = new MySqlCommand(query, connection);

                return VisitDal.createVisit(command, appointmentID);
            }

            return null;
        }

        private static Visit createVisit(MySqlCommand command, int appointmentId)
        {
            command.Parameters.Add("@appointmentId", MySqlDbType.Int16).Value = appointmentId;
            using var reader = command.ExecuteReader();
            var nurseIdOrdinal = reader.GetOrdinal("nurseId");
            var bodyTempOrdinal = reader.GetOrdinal("bodyTemp");
            var pulseOrdinal = reader.GetOrdinal("pulse");
            var heightOrdinal = reader.GetOrdinal("height");
            var weightOrdinal = reader.GetOrdinal("weight");
            var symptomsOrdinal = reader.GetOrdinal("symptoms");
            var systolicBloodPressureOrdinal = reader.GetOrdinal("systolicBloodPressure");
            var diastolicBloodPressureOrdinal = reader.GetOrdinal("diastolicBloodPressure");

            Visit visit = null;
            while (reader.Read())
            {
                visit = new Visit(appointmentId,
                    reader.GetInt32(nurseIdOrdinal),
                    reader.GetDouble(bodyTempOrdinal),
                    reader.GetInt32(pulseOrdinal),
                    reader.GetDouble(heightOrdinal),
                    reader.GetDouble(weightOrdinal),
                    reader.GetFieldValueCheckNull<string>(symptomsOrdinal),
                    reader.GetInt32(systolicBloodPressureOrdinal),
                    reader.GetInt32(diastolicBloodPressureOrdinal));
            }

            return visit;
        }

    }
}
