﻿using CS3230Project.ErrorMessages;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using CS3230Project.Model.Users.Patients;
using System.Reflection;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;

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
            comm.CommandText = "insert into patients (lastName, firstName, dateOfBirth, " +
                               "gender, phone, addressOne, addressTwo, city, state, zipcode, status) VALUES" +
                               "(@lastName, @firstName, @dateOfBirth, @gender, @phoneNumber, " +
                               "@addressOne, @addressTwo, @city, @state, @zipcode, @status)";

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
        /// Precondition:
        ///     none
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
                return PatientsDal.createPatients(command, firstName, lastName, null);
            }
            else if (firstName != null && firstName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @firstName = firstName";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName, null);
            }
            else if (lastName != null && lastName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @lastName = lastName";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName, null);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the patients by date of birth.
        /// Precondition:
        ///     none
        /// </summary>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>
        ///     Returns a list of all the patients with the provided date of birth.
        ///     Returns an empty list if there are no patients with the provided date of birth.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static List<Patient> GetPatientsByDateOfBirth(DateTime dateOfBirth)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select * from Patients where @dateOfBirth = dateOfBirth";
            using var command = new MySqlCommand(query, connection);

            return PatientsDal.createPatients(command, null, null, dateOfBirth);
        }

        /// <summary>
        /// Gets the patients by name and date of birth.
        /// Precondition:
        ///     none
        /// </summary>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <returns>
        ///     Returns a list of all the patients with the provided name and date of birth.
        ///     Returns an empty list if there are no patients with the provided name and date of birth.
        /// </returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static List<Patient> GetPatientsByNameAndDateOfBirth(string firstName, string lastName,
            DateTime dateOfBirth)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            if (firstName != null && firstName.Trim().Length > 0 && lastName != null && lastName.Trim().Length > 0)
            {
                const string query =
                    "select * from Patients where @firstName = firstName and @lastName = lastName and " +
                    "@dateOfBirth = dateOfBirth";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName, dateOfBirth);
            }
            else if (firstName != null && firstName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @firstName = firstName and @dateOfBirth = dateOfBirth";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName, dateOfBirth);
            }
            else if (lastName != null && lastName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @lastName = lastName and @dateOfBirth = dateOfBirth";
                using var command = new MySqlCommand(query, connection);
                return PatientsDal.createPatients(command, firstName, lastName, dateOfBirth);
            }
            else
            {
                return null;
            }
        }

        private static List<Patient> createPatients(MySqlCommand command, string firstName, string lastName, DateTime? dateOfBirth)
        {
            command.Parameters.Add("@firstName", MySqlDbType.String).Value = firstName;
            command.Parameters.Add("@lastName", MySqlDbType.String).Value = lastName;
            command.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = dateOfBirth;
            List<Patient> matchingPatients = new List<Patient>();

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
                matchingPatients.Add(new Patient(
                    reader.GetInt32(patientIdOrdinal),
                    reader.GetFieldValueCheckNull<string>(firstNameOrdinal),
                    reader.GetFieldValueCheckNull<string>(lastNameOrdinal),
                    reader.GetFieldValue<DateTime>(dateOfBirthOrdinal),
                    reader.GetFieldValueCheckNull<string>(genderOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal),
                    reader.GetFieldValueCheckNull<string>(phoneNumberOrdinal),
                    reader.GetFieldValue<bool>(statusOrdinal)));
            }

            return matchingPatients;
        }

        public static bool ModifyPatient(Dictionary<string, string> updatedDetails)
        {
            if (updatedDetails == null)
            {
                throw new ArgumentException(PatientErrorMessages.UpdatedPatientDetailsCannotBeNull);
            }

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            MySqlCommand comm = connection.CreateCommand();
            string commandText = "update patients set ";
            int numberOfDetailsChanged = 0;
            string patientId = "";

            foreach (var currDetail in updatedDetails)
            {
                if (numberOfDetailsChanged > 0 && !commandText[commandText.Length - 2].Equals(',') && !currDetail.Key.Equals("PatientId"))
                {
                    commandText += ", ";
                }

                switch (currDetail.Key)
                {
                    case "patientLastNameTextBox":
                        commandText += "lastName = @lastName";
                        comm.Parameters.Add("@lastName", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientFirstNameTextBox":
                        commandText += "firstName = @firstName";
                        comm.Parameters.Add("@firstName", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientDateOfBirthPicker":
                        commandText += "dateOfBirth = @dateOfBirth";
                        comm.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = DateTime.Parse(currDetail.Value);
                        numberOfDetailsChanged++;
                        break;
                    case "patientGenderComboBox":
                        commandText += "gender = @gender";
                        comm.Parameters.Add("@gender", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientPhoneNumberTextBox":
                        commandText += "phone = @phone";
                        comm.Parameters.Add("@phone", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientAddressOneTextBox":
                        commandText += "addressOne = @addressOne";
                        comm.Parameters.Add("@addressOne", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientAddressTwoTextBox":
                        commandText += "addressTwo = @addressTwo";
                        comm.Parameters.Add("@addressTwo", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientCityTextBox":
                        commandText += "city = @city";
                        comm.Parameters.Add("@city", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientStateComboBox":
                        commandText += "state = @state";
                        comm.Parameters.Add("@state", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientZipcodeTextBox":
                        commandText += "zipcode = @zipcode";
                        comm.Parameters.Add("@zipcode", MySqlDbType.String).Value = currDetail.Value;
                        numberOfDetailsChanged++;
                        break;
                    case "patientStatusComboBox":
                        commandText += "status = @status";
                        comm.Parameters.Add("@status", MySqlDbType.Int16).Value = currDetail.Value.Equals("True") ? 1 : 0;
                        numberOfDetailsChanged++;
                        break;
                    case "PatientId":
                        patientId = currDetail.Value;
                        break;
                }
            }

            commandText += " where patientID = @patientID";
            comm.Parameters.Add("@patientID", MySqlDbType.Int32).Value = patientId;
            comm.CommandText = commandText;

            return comm.ExecuteNonQuery() > 0;
        }

    }
    
    
}
