using System;
using System.Collections.Generic;
using CS3230Project.DAL.Appointments;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Appointments
{
    /// <summary>
    /// The model class for the appointment manager
    /// </summary>
    public static class AppointmentManager
    {
        /// <summary>
        /// Gets the upcoming appointments
        ///
        /// Precondition: patientId MORE THAN OR EQUAL TO 0
        /// </summary>
        /// <param name="patientId">The patient ID to search</param>
        /// <returns>The upcoming appointments for that patient</returns>
        /// <exception cref="ArgumentException">If the patient ID is less than zero</exception>
        public static List<Appointment> GetUpcomingAppointments(int patientId)
        {
            if (patientId < 0)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.PatientIdCannotBeLessThanZero);
            }
            return AppointmentsDAL.GetUpcomingAppointments(patientId);
        }

        /// <summary>
        /// Gets the previous appointments
        ///
        /// Precondition: patientId MORE THAN OR EQUAL TO 0
        /// </summary>
        /// <param name="patientId">The patient ID to search</param>
        /// <returns>The previous appointments for that patient</returns>
        /// <exception cref="ArgumentException">If the patient ID is less than zero</exception>
        public static List<Appointment> GetPreviousAppointments(int patientId)
        {
            if (patientId < 0)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.PatientIdCannotBeLessThanZero);
            }

            return AppointmentsDAL.GetPreviousAppointments(patientId);
        }
    }
}
