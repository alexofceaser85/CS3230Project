using System;
using System.Collections.Generic;
using CS3230Project.DAL.Doctors;
using CS3230Project.DAL.Patients;
using CS3230Project.Model.Appointments;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Appointments
{
    /// <summary>
    /// The data access layer for the appointments
    /// </summary>
    public static class AppointmentsDAL
    {
        /// <summary>
        /// Gets the upcoming appointment
        /// </summary>
        /// <param name="patientIdParam">The patient ID for the appointments</param>
        /// <returns>The appointments for the patient</returns>
        public static List<Appointment> GetUpcomingAppointments(int patientIdParam)
        {
            var query = "select *" +
                        "from appointments where patientId = @patientId and appointmentDateTime >= CURRENT_DATE() order by appointmentDateTime";
            return getAppointments(query, patientIdParam);
        }

        /// <summary>
        /// Gets the upcoming appointment
        /// </summary>
        /// <param name="patientIdParam">The patient ID for the appointments</param>
        /// <returns>The appointments for the patient</returns>
        public static List<Appointment> GetPreviousAppointments(int patientIdParam)
        {
            var query = "select *" +
                        "from appointments where patientId = @patientId and appointmentDateTime < CURRENT_DATE() order by appointmentDateTime";
            return getAppointments(query, patientIdParam);
        }

        /// <summary>
        /// Adds an appointment
        /// </summary>
        /// <param name="patientId">The patient ID to add an appointment for</param>
        /// <param name="appointmentDateTime">The date and time for the appointment</param>
        /// <param name="doctorId">The ID of the doctor attending the appointment</param>
        /// <param name="reason">The reason for the appointment</param>
        /// <returns>True if the appointment was added, false otherwise</returns>
        public static bool AddAppointment(int patientId, DateTime appointmentDateTime, int doctorId, string reason)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "insert into appointments (patientId, appointmentDateTime, doctorId, reason) " +
                "VALUES (@patientId, @appointmentDateTime, @doctorId, @reason)";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;
            command.Parameters.Add("@appointmentDateTime", MySqlDbType.DateTime).Value = appointmentDateTime;
            command.Parameters.Add("@doctorId", MySqlDbType.Int32).Value = doctorId;
            command.Parameters.Add("@reason", MySqlDbType.String).Value = reason;
            return command.ExecuteNonQuery() > 0;
        }

        private static List<Appointment> getAppointments(string query, int patientIdParam)
        {
            var appointments = new List<Appointment>();

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientIdParam;

            using var reader = command.ExecuteReader();
            var appointmentIdOrdinal = reader.GetOrdinal("appointmentId");
            var patientIdOrdinal = reader.GetOrdinal("patientId");
            var appointmentDateTimeOrdinal = reader.GetOrdinal("appointmentDateTime");
            var doctorIdOrdinal = reader.GetOrdinal("doctorId");
            var reasonOrdinal = reader.GetOrdinal("reason");

            while (reader.Read())
            {
                var doctor = DoctorsDAL.GetDoctorById(reader.GetInt32(doctorIdOrdinal));
                var patient = PatientsDal.GetPatientById(reader.GetInt32(patientIdOrdinal));
                if (doctor != null && patient != null)
                {
                    appointments.Add(new Appointment(
                        reader.GetInt32(appointmentIdOrdinal),
                        patient,
                        reader.GetFieldValueCheckNull<DateTime>(appointmentDateTimeOrdinal),
                        doctor,
                        reader.GetFieldValueCheckNull<string>(reasonOrdinal)
                    ));
                }
            }

            return appointments;
        }
    }
}
