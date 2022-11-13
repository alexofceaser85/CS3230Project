using CS3230Project.Model.Diagnosis;

namespace CS3230Project.ViewModel.Diagnosis
{
    /// <summary>
    ///   The view model for the diagnosis
    /// </summary>
    public static class DiagnosisManagerViewModel
    {

        /// <summary>
        /// Adds the diagnosis.
        ///
        /// Precondition: none
        /// Post-condition: the diagnosis provided is added to the database 
        /// </summary>
        /// <param name="diagnosisToAdd">The diagnosis to add.</param>
        /// <returns>
        ///   True, if the diagnosis was added to the database
        ///   False, if the diagnosis was not added to the database
        /// </returns>
        public static bool AddDiagnosis(Model.Diagnosis.Diagnosis diagnosisToAdd)
        {
            return DiagnosisManager.AddDiagnosis(diagnosisToAdd);
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
        /// Gets the diagnosis.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="appointmentId">The appointment identifier.</param>
        /// <returns>
        ///   The diagnosis with the provided appointment id
        /// </returns>
        public static Model.Diagnosis.Diagnosis GetDiagnosis(int appointmentId)
        {
            return DiagnosisManager.GetDiagnosis(appointmentId);
        }

    }
}
