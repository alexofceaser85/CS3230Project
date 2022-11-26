using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Visits
{
    /// <summary>
    ///   Holds the information for the admin search visits
    /// </summary>
    public class AdminSearchVisit
    {

        /// <summary>
        /// Gets the appointment date time.
        /// </summary>
        /// <value>The appointment date time.</value>
        public DateTime AppointmentDateTime { get; }

        /// <summary>
        /// Gets the appointment ID
        /// </summary>
        /// <value>The appointment identifier.</value>
        public int AppointmentId { get; }

        /// <summary>
        /// Gets the patient ID
        /// </summary>
        /// <value>The patient identifier.</value>
        public int PatientId { get; }

        /// <summary>
        /// Gets the first name of the patient.
        /// </summary>
        /// <value>The first name of the patient.</value>
        public string PatientFirstName { get; }

        /// <summary>
        /// Gets the last name of the patient.
        /// </summary>
        /// <value>The last name of the patient.</value>
        public string PatientLastName { get; }

        /// <summary>
        /// Gets the first name of the doctor.
        /// </summary>
        /// <value>The first name of the doctor.</value>
        public string DoctorFirstName { get; }

        /// <summary>
        /// Gets the last name of the doctor.
        /// </summary>
        /// <value>The last name of the doctor.</value>
        public string DoctorLastName { get; }

        /// <summary>
        /// Gets the first name of the nurse.
        /// </summary>
        /// <value>The first name of the nurse.</value>
        public string NurseFirstName { get; }

        /// <summary>
        /// Gets the last name of the nurse.
        /// </summary>
        /// <value>The last name of the nurse.</value>
        public string NurseLastName { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AdminSearchVisit" /> class.
        ///
        /// Precondition:   appointmentId MORE THAN OR EQUAL TO 0 AND
        ///                 patientId MORE THAN OR EQUAL TO 0 AND
        ///                 !patientFirstName.isEmpty() AND
        ///                 patientFirstName != null AND
        ///                 !patientLastName.isEmpty() AND
        ///                 patientLastName != null AND
        ///                 !doctorFirstName.isEmpty() AND
        ///                 doctorFirstName != null AND
        ///                 !doctorLastName.isEmpty() AND
        ///                 doctorLastName != null AND
        ///                 !nurseFirstName.isEmpty() AND
        ///                 nurseFirstName != null AND
        ///                 !nurseLastName.isEmpty() AND
        ///                 nurseLaseName != null
        ///                 
        /// Post-condition: a new admin search visit is created
        /// </summary>
        /// <param name="appointmentDateTime">The appointment date time.</param>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <param name="patientId">The patient identifier.</param>
        /// <param name="patientFirstName">First name of the patient.</param>
        /// <param name="patientLastName">Last name of the patient.</param>
        /// <param name="doctorFirstName">First name of the doctor.</param>
        /// <param name="doctorLastName">Last name of the doctor.</param>
        /// <param name="nurseFirstName">First name of the nurse.</param>
        /// <param name="nurseLastName">Last name of the nurse.</param>
        public AdminSearchVisit(DateTime appointmentDateTime, int appointmentId, int patientId, string patientFirstName,
            string patientLastName, string doctorFirstName, string doctorLastName, string nurseFirstName,
            string nurseLastName)
        {
            if (appointmentId < 0)
            {
                throw new ArgumentException(AppointmentErrorMessages.AppointmentIdCannotBeLessThanZero);
            }
            if (patientId < 0)
            {
                throw new ArgumentException(PatientErrorMessages.PatientIdCannotBeLessThanZero);
            }
            if (patientFirstName.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.FirstNameCannotBeEmpty);
            }
            if (patientFirstName == null)
            {
                throw new ArgumentException(PatientErrorMessages.FirstNameCannotBeNull);
            }
            if (patientLastName.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.LastNameCannotBeEmpty);
            }
            if (patientLastName == null)
            {
                throw new ArgumentException(PatientErrorMessages.LastNameCannotBeNull);
            }
            if (doctorFirstName.Trim().Length == 0)
            {
                throw new ArgumentException(DoctorErrorMessages.FirstNameCannotBeEmpty);
            }
            if (doctorFirstName == null)
            {
                throw new ArgumentException(DoctorErrorMessages.FirstNameCannotBeNull);
            }
            if (doctorLastName.Trim().Length == 0)
            {
                throw new ArgumentException(DoctorErrorMessages.LastNameCannotBeEmpty);
            }
            if (doctorLastName == null)
            {
                throw new ArgumentException(DoctorErrorMessages.LastNameCannotBeNull);
            }
            if (nurseFirstName.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.FirstNameCannotBeEmpty);
            }
            if (nurseFirstName == null)
            {
                throw new ArgumentException(NurseErrorMessages.FirstNameCannotBeNull);
            }
            if (nurseLastName.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.LastNameCannotBeEmpty);
            }
            if (nurseLastName == null)
            {
                throw new ArgumentException(NurseErrorMessages.LastNameCannotBeNull);
            }

            this.AppointmentDateTime = appointmentDateTime;
            this.AppointmentId = appointmentId;
            this.PatientId = patientId;
            this.PatientFirstName = patientFirstName;
            this.PatientLastName = patientLastName;
            this.DoctorFirstName = doctorFirstName;
            this.DoctorLastName = doctorLastName;
            this.NurseFirstName = nurseFirstName;
            this.NurseLastName = nurseLastName;
        }

    }
}
