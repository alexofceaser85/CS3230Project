using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Model.Users;
using CS3230Project.Model.Users.Patients;

namespace CS3230Project.Model.Appointments
{
    /// <summary>
    /// The appointment
    /// </summary>
    public class Appointment
    {
        /// <summary>
        /// The appointment Id
        /// </summary>
        public int AppointmentId { get; }
        /// <summary>
        /// The patient the appointment is for
        /// </summary>
        public Patient Patient { get; }
        /// <summary>
        /// The date the appointment is on
        /// </summary>
        public DateTime Date { get; }
        /// <summary>
        /// The doctor attending the appointment
        /// </summary>
        public Doctor Doctor { get; }
        /// <summary>
        /// The reason for the appointment
        /// </summary>
        public string Reason { get; }
        /// <summary>
        /// Initializes a new <see cref="Appointment"/>
        /// </summary>
        /// <param name="patient"></param>
        /// <param name="date"></param>
        /// <param name="doctor"></param>
        /// <param name="reason"></param>
        /// <exception cref="ArgumentException"></exception>
        public Appointment(int appointmentId, Patient patient, DateTime date, Doctor doctor, string reason)
        {
            if (appointmentId < 0)
            {
                //TODO Add error message
                throw new ArgumentException();
            }
            if (patient == null)
            {
                throw new ArgumentException(AppointmentErrorMessages.PatientCannotBeNull);
            }

            if (doctor == null)
            {
                throw new ArgumentException(AppointmentErrorMessages.DoctorCannotBeNull);
            }

            if (reason == null)
            {
                throw new ArgumentException(AppointmentErrorMessages.ReasonCannotBeNull);
            }

            if (reason.Trim().Length == 0)
            {
                throw new ArgumentException(AppointmentErrorMessages.ReasonCannotBeEmpty);
            }

            if (reason.Length > 100)
            {
                throw new ArgumentException(AppointmentErrorMessages.ReasonCannotBeTooLong);
            }

            this.AppointmentId = appointmentId;
            this.Patient = patient;
            this.Date = date;
            this.Doctor = doctor;
            this.Reason = reason;
        }
    }
}
