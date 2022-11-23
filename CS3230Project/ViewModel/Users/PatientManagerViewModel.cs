using System;
using System.Collections.Generic;
using CS3230Project.Model.Users.Patients;

namespace CS3230Project.ViewModel.Users
{
    /// <summary>
    /// The view model for the patients
    /// </summary>
    public static class PatientManagerViewModel
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

        /// <summary>
        /// Gets the patient by name
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="firstName">The first name of the patient to get</param>
        /// <param name="lastName">The last name of the patient to get</param>
        /// <returns>The patients with the matching name</returns>
        public static List<Patient> GetPatientsByName(string firstName, string lastName)
        {
            return PatientManager.GetPatientsByName(firstName, lastName);
        }

        /// <summary>
        /// Gets the patients by date of birth
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="dateOfBirth">The date of birth of the patient to get</param>
        /// <returns>The patients with the matching date of birth</returns>
        public static List<Patient> GetPatientsByDateOfBirth(DateTime dateOfBirth)
        {
            return PatientManager.GetPatientsByDateOfBirth(dateOfBirth);
        }

        /// <summary>
        /// Gets the patients by name and date of birth
        ///
        /// Precondition: None
        /// Postcondition: None
        /// </summary>
        /// <param name="firstName">The first name of the patient to get</param>
        /// <param name="lastName">The last name of the patient to get</param>
        /// <param name="dateOfBirth">The date of birth of the patient to get</param>
        /// <returns>The patients with a matching first name, last name, and date of birth</returns>
        public static List<Patient> GetPatientsByNameAndDateOfBirth(string firstName, string lastName,
            DateTime dateOfBirth)
        {
            return PatientManager.GetPatientsByNameAndDateOfBirth(firstName, lastName, dateOfBirth);
        }

        /// <summary>
        /// Modifies the patient.
        ///
        /// Precondition: none
        /// Post-condition: none
        /// </summary>
        /// <param name="modifiedPatient">The modified patient.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        public static bool ModifyPatient(Patient modifiedPatient)
        {
            return PatientManager.ModifyPatient(modifiedPatient);
        }
    }
}