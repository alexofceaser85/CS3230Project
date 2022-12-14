using System;
using System.Collections.Generic;
using CS3230Project.Model.Appointments;

namespace CS3230Project.ViewModel.Appointments
{
    /// <summary>
    /// The view model for the appointment manager
    /// </summary>
    public static class AppointmentManagerViewModel
    {
        /// <summary>
        /// Gets the upcoming appointments
        /// </summary>
        /// <param name="patientId">The patientID for the appointment</param>
        /// <returns>The appointments for the ID</returns>
        public static List<Appointment> GetUpcomingAppointments(int patientId)
        {
            return AppointmentManager.GetUpcomingAppointments(patientId);
        }

        /// <summary>
        /// Gets the previous appointments
        /// </summary>
        /// <param name="patientId">The patientID for the appointment</param>
        /// <returns>The appointments for the ID</returns>
        public static List<Appointment> GetPreviousAppointments(int patientId)
        {
            return AppointmentManager.GetPreviousAppointments(patientId);
        }
        /// <summary>
        /// Adds an appointment
        /// </summary>
        /// <param name="patientId">The patient ID to add an appointment for</param>
        /// <param name="appointmentDateTime">The date and time of the appointment</param>
        /// <param name="doctorId">The ID of the attending doctor</param>
        /// <param name="reason">The reason for the appointment</param>
        /// <returns></returns>
        public static bool AddAppointment(int patientId, DateTime appointmentDateTime, int doctorId,
            string reason)
        {
            return AppointmentManager.AddAppointment(patientId, appointmentDateTime, doctorId, reason);
        }

        /// <summary>
        /// Modifies an existing appointment
        /// </summary>
        /// <param name="appointmentId">The modified appointment ID</param>
        /// <param name="modifiedAppointmentDateTime">The modified appointment ID</param>
        /// <param name="modifiedDoctorId">The modified appointment doctor id</param>
        /// <param name="modifiedReason">The modified appointment reason</param>
        /// <returns>True if the appointment was modified, false otherwise</returns>
        public static bool ModifyAppointment(int appointmentId, DateTime modifiedAppointmentDateTime, int modifiedDoctorId, string modifiedReason)
        {
            return AppointmentManager.ModifyAppointment(appointmentId, modifiedAppointmentDateTime, modifiedDoctorId, modifiedReason);
        }
    }
}
