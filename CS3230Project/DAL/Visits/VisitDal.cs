using System;
using CS3230Project.ErrorMessages;
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
        /// Precondition: visitToAdd != null
        /// Post-condition: visits.length == visits.length @prev  + 1
        /// </summary>
        /// <param name="visitToAdd">The visit to add.</param>
        /// <returns>
        ///   returns true if the visit was added to the database
        ///   returns false if the visit was not added to the database
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool AddVisit(Visit visitToAdd)
        {
            if (visitToAdd == null)
            {
                throw new ArgumentException(VisitErrorMessages.VisitToAddCannotBeNull);
            }

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

    }
}
