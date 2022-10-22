using System.Collections.Generic;
using CS3230Project.Model.Appointments;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Appointments
{
    public static class AppointmentsDAL
    {
        public static List<Appointment> GetUpcomingAppointments(int patientId)
        {
            var appointments = new List<Appointment>();

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select appointmentId, patientId, appointmentDateTime, doctorId, reason" +
                                 "from appointments where patientId = @patientId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;

            using var reader = command.ExecuteReader();
            var appointmentIdOrdinal = reader.GetOrdinal("appointmentId");
            var patientIdOrdinal = reader.GetOrdinal("patientId");
            var appointmentDateTimeOrdinal = reader.GetOrdinal("appointmentDateTime");
            var doctorIdOrdinal = reader.GetOrdinal("doctorId");
            var reasonOrdinal = reader.GetOrdinal("reason");
        }
    }
}
