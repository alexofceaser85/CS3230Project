﻿using CS3230Project.ErrorMessages;
using CS3230Project.Model.Users;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CS3230Project.DAL.Patients
{
    /// <summary>
    ///   The data access layer for the patients
    /// </summary>
    public static class PatientsDal
    {

        /// <summary>
        /// Adds the patient.
        ///
        /// Precondition:
        ///     patient != null
        /// </summary>
        /// <param name="patientToAdd">The patient to add.</param>
        /// <returns>
        ///     Returns true if the patient was added to the database.
        ///     Returns false if the patient was not added to the database.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool AddPatient(Patient patientToAdd)
        {
            if (patientToAdd == null)
            {
                throw new ArgumentException(PatientErrorMessages.PatientToAddCannotBeNull);
            }

            int patientId = patientToAdd.PatientId;
            string firstName = patientToAdd.FirstName;
            string lastName = patientToAdd.LastName;
            DateTime dateOfBirth = patientToAdd.DateOfBirth;
            string gender = patientToAdd.Gender;
            string phoneNumber = patientToAdd.PhoneNumber;
            string addressOne = patientToAdd.AddressOne;
            string addressTwo = patientToAdd.AddressTwo;
            string city = patientToAdd.City;
            string state = patientToAdd.State;
            string zipcode = patientToAdd.Zipcode;
            bool status = patientToAdd.Status;

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            MySqlCommand comm = connection.CreateCommand();
            comm.CommandText = "insert into patients (patientID, lastName, firstName, dateOfBirth, " +
                               "gender, phone, addressOne, addressTwo, city, state, zipcode, status) VALUES" +
                               "(@patientId, @lastName, @firstName, @dateOfBirth, @gender, @phoneNumber, " +
                               "@addressOne, @addressTwo, @city, @state, @zipcode, @status)";

            comm.Parameters.Add("@patientId", MySqlDbType.String).Value = patientId;
            comm.Parameters.Add("@lastName", MySqlDbType.String).Value = lastName;
            comm.Parameters.Add("@firstName", MySqlDbType.String).Value = firstName;
            comm.Parameters.Add("@dateOfBirth", MySqlDbType.String).Value = dateOfBirth;
            comm.Parameters.Add("@gender", MySqlDbType.String).Value = gender;
            comm.Parameters.Add("@phoneNumber", MySqlDbType.String).Value = phoneNumber;
            comm.Parameters.Add("@addressOne", MySqlDbType.String).Value = addressOne;
            comm.Parameters.Add("@addressTwo", MySqlDbType.String).Value = addressTwo;
            comm.Parameters.Add("@city", MySqlDbType.String).Value = city;
            comm.Parameters.Add("@state", MySqlDbType.String).Value = state;
            comm.Parameters.Add("@zipcode", MySqlDbType.String).Value = zipcode;
            comm.Parameters.Add("@status", MySqlDbType.String).Value = status;

            return comm.ExecuteNonQuery() > 0;

        }

        /// <summary>
        /// Gets all the patients with the provided name.
        /// Precondition: none
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns>
        ///     Returns a list of all the patients with the provided name.
        ///     Returns an empty list if there are no patients with the provided name.
        /// </returns>
        public static List<Patient> GetPatientsByName(string firstName, string lastName)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            if (firstName != null && firstName.Trim().Length > 0 && lastName != null && lastName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @firstName = firstName and @lastName = lastName";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName);
            }
            else if (firstName != null && firstName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @firstName = firstName";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName);
            }
            else if (lastName != null && lastName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @lastName = lastName";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName);
            }
            else
            {
                return null;
            }
        }

        private static List<Patient> createPatients(MySqlCommand command, string firstName, string lastName)
        {
            command.Parameters.Add("@firstName", MySqlDbType.String).Value = firstName;
            command.Parameters.Add("@lastName", MySqlDbType.String).Value = lastName;
            List<Patient> patientsWithMatchingName = new List<Patient>();

            using var reader = command.ExecuteReader();
            var patientIdOrdinal = reader.GetOrdinal("patientID");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var dateOfBirthOrdinal = reader.GetOrdinal("dateOfBirth");
            var genderOrdinal = reader.GetOrdinal("gender");
            var phoneNumberOrdinal = reader.GetOrdinal("phone");
            var addressOneOrdinal = reader.GetOrdinal("addressOne");
            var addressTwoOrdinal = reader.GetOrdinal("addressTwo");
            var cityOrdinal = reader.GetOrdinal("city");
            var stateOrdinal = reader.GetOrdinal("state");
            var zipcodeOrdinal = reader.GetOrdinal("zipcode");
            var statusOrdinal = reader.GetOrdinal("status");

            while (reader.Read())
            {
                patientsWithMatchingName.Add(new Patient(
                    patientIdOrdinal,
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValue<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneNumberOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal),
                    reader.GetFieldValue<bool>(statusOrdinal)));
            }

            return patientsWithMatchingName;
        }

    }
}