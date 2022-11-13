using System;
using CS3230Project.DAL.Diagnosis;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Diagnosis
{
    /// <summary>
    ///   Manages access and manipulation of the diagnosis
    /// </summary>
    public static class DiagnosisManager
    {

        /// <summary>
        /// Adds the diagnosis.
        ///
        /// Precondition: diagnosisToAdd != null
        /// Post-condition: the diagnosis is added to the database
        /// </summary>
        /// <param name="diagnosisToAdd">The diagnosis to add.</param>
        /// <returns>
        ///   True if the diagnosis was added to the database
        ///   False if the diagnosis was not added to the database
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool AddDiagnosis(Diagnosis diagnosisToAdd)
        {
            if (diagnosisToAdd == null)
            {
                throw new ArgumentException(DiagnosisErrorMessages.DiagnosisToAddCannotBeNull);
            }

            return DiagnosisDal.AddDiagnosis(diagnosisToAdd);
        }

        /// <summary>
        /// Modifies the diagnosis.
        ///
        /// Precondition: modifiedDiagnosis != null
        /// Post-condition: the diagnosis is modified with the provided details
        /// </summary>
        /// <param name="modifiedDiagnosis">The diagnosis to modify.</param>
        /// <returns>
        ///   true if the diagnosis was modified with the provided details
        ///   false if the diagnosis was not modified with the provided details
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool ModifyDiagnosis(Diagnosis modifiedDiagnosis)
        {
            if (modifiedDiagnosis == null)
            {
                throw new ArgumentException(DiagnosisErrorMessages.ModifiedDiagnosisCannotBeNull);
            }

            return DiagnosisDal.ModifyDiagnosis(modifiedDiagnosis);
        }

        /// <summary>
        /// Gets the diagnosis.
        ///
        /// Precondition: appointmentId MORE THAN OR EQUAL TO 0
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        ///   The diagnosis, if exists
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static Diagnosis GetDiagnosis(int appointmentId)
        {
            if (appointmentId < 0)
            {
                throw new ArgumentException(DiagnosisErrorMessages.DiagnosisIdCannotBeLessThanZero);
            }

            return DiagnosisDal.GetDiagnosis(appointmentId);
        }

    }
}
