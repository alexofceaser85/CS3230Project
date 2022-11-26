using System.Collections.Generic;
using CS3230Project.Model.Diagnosis;

namespace CS3230Project.ViewModel.Diagnosis
{
    /// <summary>
    ///   The view model for the diagnosis
    /// </summary>
    public static class DiagnosisManagerViewModel
    {

        /// <summary>
        /// Adds diagnoses.
        ///
        /// Precondition: none
        /// Post-condition: the diagnoses provided is added to the database 
        /// </summary>
        /// <param name="diagnosesToAdd">The diagnoses to add.</param>
        /// <returns>
        ///   True, if the diagnoses were added to the database
        ///   False, if the diagnoses were not added to the database
        /// </returns>
        public static bool AddDiagnoses(List<Model.Diagnosis.Diagnosis> diagnosesToAdd)
        {
            return DiagnosisManager.AddDiagnoses(diagnosesToAdd);
        }

        /// <summary>
        /// Modifies the diagnosis.
        ///
        /// Precondition: none
        /// Post-condition: the provided diagnosis is modified with the provided details
        /// </summary>
        /// <param name="modifiedDiagnosis">The modified diagnosis.</param>
        /// <returns>
        ///   True, if the diagnosis was modified
        ///   False, if the diagnosis was not modified
        /// </returns>
        public static bool ModifyDiagnosis(Model.Diagnosis.Diagnosis modifiedDiagnosis)
        {
            return DiagnosisManager.ModifyDiagnosis(modifiedDiagnosis);
        }

        /// <summary>
        /// Gets the diagnoses.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        ///   The diagnoses with the provided appointment id
        /// </returns>
        public static List<Model.Diagnosis.Diagnosis> GetDiagnoses(int appointmentId)
        {
            return DiagnosisManager.GetDiagnoses(appointmentId);
        }

        /// <summary>
        /// Removes the diagnosis.
        ///
        /// Precondition: none
        /// Post-condition: the diagnosis is removed from the database
        /// </summary>
        /// <param name="diagnosisId">The diagnosis identifier.</param>
        /// <returns>
        ///   True, if the diagnosis is removed
        ///   False, if the diagnosis is not removed
        /// </returns>
        public static bool RemoveDiagnosis(int diagnosisId)
        {
            return DiagnosisManager.RemoveDiagnosis(diagnosisId);
        }

    }
}
