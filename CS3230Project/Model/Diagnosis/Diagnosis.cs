using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Diagnosis
{
    /// <summary>
    ///   Holds the diagnosis information
    /// </summary>
    public class Diagnosis
    {
        /// <summary>
        /// Gets the diagnosis identifier.
        /// </summary>
        public int DiagnosisId { get; }
        /// <summary>
        /// Gets the appointment identifier.
        /// </summary>
        public int AppointmentId { get; }
        /// <summary>
        /// Gets the diagnosis description.
        /// </summary>
        public string DiagnosisDescription { get; }
        /// <summary>
        /// Gets a value indicating whether this instance is final.
        /// </summary>
        public bool IsFinal { get; }
        /// <summary>
        /// Gets a value indicating whether [based on test results].
        /// </summary>
        public bool BasedOnTestResults { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Diagnosis" /> class.
        ///
        /// Precondition:   diagnosisId MORE THAN OR EQUAL TO 0
        ///                 AND appointmentId MORE THAN OR EQUAL TO 0
        ///                 AND !DiagnosisDescription.isEmpty()
        ///                 AND DiagnosisDescription != null
        /// </summary>
        /// <param name="diagnosisId">The diagnosis identifier.</param>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <param name="diagnosisDescription">The diagnosis description.</param>
        /// <param name="isFinal">if set to <c>true</c> [is final].</param>
        /// <param name="basedOnTestResults">if set to <c>true</c> [based on test results].</param>
        /// <exception cref="System.ArgumentException"></exception>
        public Diagnosis(int diagnosisId, int appointmentId, string diagnosisDescription, bool isFinal, bool basedOnTestResults)
        {
            if (diagnosisId < 0)
            {
                throw new ArgumentException(DiagnosisErrorMessages.DiagnosisIdCannotBeLessThanZero);
            }
            if (appointmentId < 0)
            {
                throw new ArgumentException(DiagnosisErrorMessages.AppointmentIdCannotBeLessThanZero);
            }
            if (diagnosisDescription.Trim().Length == 0)
            {
                throw new ArgumentException(DiagnosisErrorMessages.DiagnosisDescriptionCannotBeEmpty);
            }
            if (diagnosisDescription == null)
            {
                throw new ArgumentException(DiagnosisErrorMessages.DiagnosisDescriptionCannotBeNull);
            }

            this.DiagnosisId = diagnosisId;
            this.AppointmentId = appointmentId;
            this.DiagnosisDescription = diagnosisDescription;
            this.IsFinal = isFinal;
            this.BasedOnTestResults = basedOnTestResults;
        }
    }
}
