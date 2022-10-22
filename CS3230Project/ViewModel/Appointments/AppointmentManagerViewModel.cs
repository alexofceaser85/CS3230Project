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
    }
}
