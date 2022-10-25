using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Visits;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Visits
{
    public class VisitDal
    {

        public static bool AddVisit(Visit visitToAdd)
        {
            if (visitToAdd == null)
            {
                throw new ArgumentException(VisitErrorMessages.VisitToAddCannotBeNull);
            }

            var appointmentID = visitToAdd.appointmentID;
            var nurseID = visitToAdd.nurseID;
            var bodyTemp = visitToAdd.bodyTemp;
            var pulse = visitToAdd.pulse;
            var height = visitToAdd.height;
            var weight = visitToAdd.weight;
            var symptoms = visitToAdd.symptoms;
            var systolicBloodPressure = visitToAdd.systolicBloodPressure;
            var diastolicBloodPressure = visitToAdd.diastolicBloodPressure;

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
