﻿using CS3230Project.DAL.Patients;
using CS3230Project.Model.Users;
using System.Collections.Generic;

namespace CS3230Project.Model.Patients
{
    /// <summary>
    ///   Manages access and manipulation of the patients
    /// </summary>
    public static class PatientManager
    {

        /// <summary>
        /// Gets all the patients with the provided name
        /// Precondition:
        ///     None
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns>
        ///     Returns a list of the patients with the provided name.
        ///     Returns null if no name provided.
        ///     Returns an empty list if there are no patients with the provided name
        /// </returns>
        public static List<Patient> GetPatientsByName(string firstName, string lastName)
        {
            return PatientsDal.GetPatientsByName(firstName, lastName);
        }

    }
}
