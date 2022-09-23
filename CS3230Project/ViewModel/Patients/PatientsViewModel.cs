using CS3230Project.Model.Patients;
using CS3230Project.Model.Users;

namespace CS3230Project.ViewModel.Patients
{
    /// <summary>
    /// The view model for the patients
    /// </summary>
    public static class PatientsViewModel
    {
        /// <summary>
        /// Adds a patient
        ///
        /// Precondition: None
        /// Postcondition: The patient is added
        /// </summary>
        /// <param name="patientToAdd">The patient to add</param>
        /// <returns></returns>
        public static bool AddPatient(Patient patientToAdd)
        {
            return PatientManager.AddPatient(patientToAdd);
        }
    }
}
