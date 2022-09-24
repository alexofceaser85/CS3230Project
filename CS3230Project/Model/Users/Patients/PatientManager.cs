﻿using System;
using System.Collections.Generic;
using CS3230Project.DAL.Patients;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Users.Patients
{
    /// <summary>
    ///   Manages access and manipulation of the patients
    /// </summary>
    public static class PatientManager
    {

        /// <summary>
        /// Gets all the patients with the provided name
        /// Precondition:
        ///     (firstName != null && firstName.Trim().Length > 0) ||
        ///         (lastName != null && lastName.Trim().Length > 0)
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns>
        ///     Returns a list of the patients with the provided name.
        ///     Returns null if no name provided.
        ///     Returns an empty list if there are no patients with the provided name.
        /// </returns>
        public static List<Patient> GetPatientsByName(string firstName, string lastName)
        {
            if ((firstName == null || firstName.Trim().Length == 0) &&
                (lastName == null || lastName.Trim().Length == 0))
            {
                throw new ArgumentException(PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
            }

            return PatientsDal.GetPatientsByName(firstName, lastName);
        }

        /// <summary>
        /// Gets the patients with the provided date of birth.
        /// Precondition:
        ///     dateOfBirth > DateTime(1900, 1, 1)
        ///     AND dateOfBirth < DateTime.Now()
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>
        ///     Returns a list of the patients with the provided date of birth.
        ///     Returns an empty list if there are no patients with the provided date of birth.
        /// </returns>
        public static List<Patient> GetPatientsByDateOfBirth(DateTime dateOfBirth)
        {
            if (dateOfBirth < new DateTime(1900, 1, 1))
            {
                throw new ArgumentException(PatientErrorMessages.DateOfBirthCannotBeBefore1900);
            }

            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
            }

            return PatientsDal.GetPatientsByDateOfBirth(dateOfBirth);
        }

        /// <summary>
        /// Gets the patients with the provided name and date of birth.
        /// Precondition:
        ///     (firstName != null && firstName.Trim().Length > 0) ||
        ///         (lastName != null && lastName.Trim().Length > 0)
        ///     AND dateOfBirth > DateTime(1900, 1, 1)
        ///     AND dateOfBirth < DateTime.Now()
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>
        ///     Returns a list of the patients with the provided name and date of birth.
        ///     Returns null if no name provided.
        ///     Returns an empty list if there are no patients with the provided name and date of birth.
        /// </returns>
        public static List<Patient> GetPatientsByNameAndDateOfBirth(string firstName, string lastName,
            DateTime dateOfBirth)
        {
            if ((firstName == null || firstName.Trim().Length == 0) &&
                (lastName == null || lastName.Trim().Length == 0))
            {
                throw new ArgumentException(PatientErrorMessages.FirstAndLastNamesCannotBothBeNullOrEmpty);
            }
            if (dateOfBirth < new DateTime(1900, 1, 1))
            {
                throw new ArgumentException(PatientErrorMessages.DateOfBirthCannotBeBefore1900);
            }
            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
            }

            return PatientsDal.GetPatientsByNameAndDateOfBirth(firstName, lastName, dateOfBirth);
        }

    }
}