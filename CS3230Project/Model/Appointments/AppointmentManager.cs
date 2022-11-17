using System;
using System.Collections.Generic;
using CS3230Project.DAL.Appointments;
using CS3230Project.ErrorMessages;
using CS3230Project.Settings;

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
                throw new ArgumentException(AppointmentManagerErrorMessages.PatientIdToGetCannotBeLessThanZero);
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
                throw new ArgumentException(AppointmentManagerErrorMessages.PatientIdToGetCannotBeLessThanZero);
            }

            return AppointmentsDAL.GetPreviousAppointments(patientId);
        }

        /// <summary>
        /// Adds a new appointment
        ///
        /// Precondition:
        /// patientId MORE THAN OR EQUAL TO 0
        /// appointmentDate MORE THAN OR EQUAL TO today's date
        /// doctorId MORE THAN OR EQUAL TO 0
        /// reason != null
        /// reason.Length MORE THAN 0
        /// reason.Length LESS THAN Max Length
        /// Postcondition:
        /// Appointment is added
        /// </summary>
        /// <param name="patientId">The ID of the patient the appointment is for</param>
        /// <param name="appointmentDateTime">The date and time of the appointment</param>
        /// <param name="doctorId">The ID of the appointment's doctor</param>
        /// <param name="reason">The reason for the appointment</param>
        /// <returns>True if the appointment was added, false otherwise</returns>
        /// <exception cref="ArgumentException">If the Preconditions are not met</exception>
        public static bool AddAppointment(int patientId, DateTime appointmentDateTime, int doctorId, string reason)
        {
            if (patientId < 0)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.PatientIdToAddCannotBeLessThanZero);
            }

            if (appointmentDateTime < DateTime.Today)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages
                    .DateTimeCannotBeInThePast);
            }

            if (doctorId < 0)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages
                    .DoctorIdToAddCannotBeLessThanZero);
            }

            if (reason == null)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.AppointmentReasonCannotBeNull);
            }

            if (reason.Trim().Length == 0)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.AppointmentReasonCannotBeEmpty);
            }

            if (reason.Length > AppointmentSettings.AppointmentReasonMaximumLength)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.AppointmentReasonCannotBeAboveMaxLength);
            }

            var roundedAppointmentDateTime = new DateTime(appointmentDateTime.Year, appointmentDateTime.Month,
                appointmentDateTime.Day, appointmentDateTime.Hour, appointmentDateTime.Minute, 0);

            return AppointmentsDAL.AddAppointment(patientId, roundedAppointmentDateTime, doctorId, reason);
        }

        /// <summary>
        /// Modifies an appointment
        ///
        /// Precondition:
        ///     modifiedAppointmentDateTime MORE THAN Current Day
        ///     AND modifiedDoctorId MORE THAN OR EQUAL TO 0
        ///     AND modifiedReason != null
        ///     AND modifiedReason.Length != 0
        /// Postcondition:
        ///     The appointment info is modified
        /// </summary>
        /// <param name="appointmentId">The ID of the appointment to modify</param>
        /// <param name="modifiedAppointmentDateTime">The appointment date time</param>
        /// <param name="modifiedDoctorId">The doctor ID</param>
        /// <param name="modifiedReason">The reason</param>
        /// <returns></returns>
        public static bool ModifyAppointment(int appointmentId, DateTime modifiedAppointmentDateTime, int modifiedDoctorId, string modifiedReason)
        {

            if (modifiedAppointmentDateTime < DateTime.Today)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages
                    .DateTimeCannotBeInThePast);
            }

            if (modifiedDoctorId < 0)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages
                    .DoctorIdToAddCannotBeLessThanZero);
            }

            if (modifiedReason == null)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.AppointmentReasonCannotBeNull);
            }

            if (modifiedReason.Trim().Length == 0)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.AppointmentReasonCannotBeEmpty);
            }

            if (modifiedReason.Length > AppointmentSettings.AppointmentReasonMaximumLength)
            {
                throw new ArgumentException(AppointmentManagerErrorMessages.AppointmentReasonCannotBeAboveMaxLength);
            }

            return AppointmentsDAL.ModifyAppointment(appointmentId, modifiedAppointmentDateTime, modifiedDoctorId, modifiedReason);
        }
    }
}
