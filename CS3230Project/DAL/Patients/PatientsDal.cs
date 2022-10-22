using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using CS3230Project.ErrorMessages;
using CS3230Project.Model;
using CS3230Project.Model.Users.Patients;
using CS3230Project.Settings;
using CS3230Project.View;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.AxHost;

namespace CS3230Project.DAL.Patients
{
    /// <summary>
    ///     The data access layer for the patients
    /// </summary>
    public static class PatientsDal
    {
        private static string editPatientErrorHeader = "Unable To Edit Patient";

        /// <summary>
        ///     Adds the patient.
        ///     Precondition:
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

            var patientId = patientToAdd.PatientId;
            var firstName = patientToAdd.FirstName;
            var lastName = patientToAdd.LastName;
            var dateOfBirth = patientToAdd.DateOfBirth;
            var gender = patientToAdd.Gender;
            var phoneNumber = patientToAdd.PhoneNumber;
            var addressOne = patientToAdd.AddressOne;
            var addressTwo = patientToAdd.AddressTwo;
            var city = patientToAdd.City;
            var state = patientToAdd.State;
            var zipcode = patientToAdd.Zipcode;
            var status = patientToAdd.Status;

            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var comm = connection.CreateCommand();
            comm.CommandText = "insert into patients (lastName, firstName, dateOfBirth, " +
                               "gender, phone, addressOne, addressTwo, city, state, zipcode, status) VALUES" +
                               "(@lastName, @firstName, @dateOfBirth, @gender, @phoneNumber, " +
                               "@addressOne, @addressTwo, @city, @state, @zipcode, @status)";

            comm.Parameters.Add("@lastName", MySqlDbType.String).Value = lastName;
            comm.Parameters.Add("@firstName", MySqlDbType.String).Value = firstName;
            comm.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = dateOfBirth;
            comm.Parameters.Add("@gender", MySqlDbType.String).Value = gender;
            comm.Parameters.Add("@phoneNumber", MySqlDbType.String).Value = phoneNumber;
            comm.Parameters.Add("@addressOne", MySqlDbType.String).Value = addressOne;
            comm.Parameters.Add("@addressTwo", MySqlDbType.String).Value = addressTwo;
            comm.Parameters.Add("@city", MySqlDbType.String).Value = city;
            comm.Parameters.Add("@state", MySqlDbType.String).Value = state;
            comm.Parameters.Add("@zipcode", MySqlDbType.String).Value = zipcode;
            comm.Parameters.Add("@status", MySqlDbType.Int16).Value = status;

            return comm.ExecuteNonQuery() > 0;
        }

        public static Patient GetPatientById(int patientId)
        {
            Patient patient = null;
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query =
                "select *" +
                "from patients where patientID = @patientId";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@patientId", MySqlDbType.Int32).Value = patientId;

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
                patient = new Patient(
                    reader.GetInt32(patientIdOrdinal),
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
                    reader.GetFieldValue<bool>(statusOrdinal));
            }

            return patient;
        }

        /// <summary>
        ///     Gets all the patients with the provided name.
        ///     Precondition:
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
                return createPatients(command, firstName, lastName, null);
            }

            if (firstName != null && firstName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @firstName = firstName";
                using var command = new MySqlCommand(query, connection);
                return createPatients(command, firstName, lastName, null);
            }

            if (lastName != null && lastName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @lastName = lastName";
                using var command = new MySqlCommand(query, connection);
                return createPatients(command, firstName, lastName, null);
            }

            return null;
        }

        /// <summary>
        ///     Gets the patients by date of birth.
        ///     Precondition:
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

            return createPatients(command, null, null, dateOfBirth);
        }

        /// <summary>
        ///     Gets the patients by name and date of birth.
        ///     Precondition:
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
                return createPatients(command, firstName, lastName, dateOfBirth);
            }

            if (firstName != null && firstName.Trim().Length > 0)
            {
                const string query =
                    "select * from Patients where @firstName = firstName and @dateOfBirth = dateOfBirth";
                using var command = new MySqlCommand(query, connection);
                return createPatients(command, firstName, lastName, dateOfBirth);
            }

            if (lastName != null && lastName.Trim().Length > 0)
            {
                const string query = "select * from Patients where @lastName = lastName and @dateOfBirth = dateOfBirth";
                using var command = new MySqlCommand(query, connection);
                return createPatients(command, firstName, lastName, dateOfBirth);
            }

            return null;
        }

        private static List<Patient> createPatients(MySqlCommand command, string firstName, string lastName,
            DateTime? dateOfBirth)
        {
            command.Parameters.Add("@firstName", MySqlDbType.String).Value = firstName;
            command.Parameters.Add("@lastName", MySqlDbType.String).Value = lastName;
            command.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = dateOfBirth;
            var matchingPatients = new List<Patient>();

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
                    reader.GetFieldValueCheckNull<string>(phoneNumberOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressOneOrdinal),
                    reader.GetFieldValueCheckNull<string>(addressTwoOrdinal),
                    reader.GetFieldValueCheckNull<string>(cityOrdinal),
                    reader.GetFieldValueCheckNull<string>(stateOrdinal),
                    reader.GetFieldValueCheckNull<string>(zipcodeOrdinal),
                    reader.GetFieldValue<bool>(statusOrdinal)));
            }

            return matchingPatients;
        }

        /// <summary>
        ///     Modifies the patient.
        ///     Precondition:
        ///     None
        /// </summary>
        /// <param name="updatedDetails">The updated details.</param>
        /// <returns>
        ///     True, if the patient was modified
        /// </returns>
        public static bool ModifyPatient(Dictionary<string, string> updatedDetails)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            var comm = connection.CreateCommand();
            var commandText = "update patients set ";
            var numberOfDetailsChanged = 0;
            var patientId = "";

            foreach (var currDetail in updatedDetails)
            {
                if (numberOfDetailsChanged > 0 && !commandText[commandText.Length - 2].Equals(',') && !currDetail.Key.Equals("PatientId"))
                {
                    commandText += ", ";
                }

                switch (currDetail.Key)
                {
                    case "patientLastNameTextBox":
                        if (currDetail.Value.Length <= PatientSettings.NameMaximumLength)
                        {
                            commandText += "lastName = @lastName";
                            comm.Parameters.Add("@lastName", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.LastNameIsTooLong, editPatientErrorHeader);
                            return false;
                        }
                        break;
                        case "patientFirstNameTextBox":
                        if (currDetail.Value.Length <= PatientSettings.NameMaximumLength)
                        {
                            commandText += "firstName = @firstName";
                            comm.Parameters.Add("@firstName", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.FirstNameIsTooLong, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientDateOfBirthPicker":
                        commandText += "dateOfBirth = @dateOfBirth";
                        comm.Parameters.Add("@dateOfBirth", MySqlDbType.Date).Value = DateTime.Parse(currDetail.Value);
                        numberOfDetailsChanged++;
                        break;
                    case "patientGenderComboBox":
                        if (currDetail.Value.Length <= PatientSettings.GenderMaximumLength)
                        {
                            commandText += "gender = @gender";
                            comm.Parameters.Add("@gender", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.GenderIsTooLong, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientPhoneNumberTextBox":
                        if (DataValidator.IsValidPhoneNumberFormat(currDetail.Value))
                        {
                            commandText += "phone = @phone";
                            comm.Parameters.Add("@phone", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.InvalidPhoneNumberFormat, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientAddressOneTextBox":
                        if (currDetail.Value.Length <= PatientSettings.AddressComponentMaximumLength)
                        {
                            commandText += "addressOne = @addressOne";
                            comm.Parameters.Add("@addressOne", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.AddressOneIsTooLong, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientAddressTwoTextBox":
                        if (currDetail.Value.Length <= PatientSettings.AddressComponentMaximumLength)
                        {
                            commandText += "addressTwo = @addressTwo";
                            comm.Parameters.Add("@addressTwo", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.AddressTwoIsTooLong, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientCityTextBox":
                        if (currDetail.Value.Length <= PatientSettings.AddressComponentMaximumLength)
                        {
                            commandText += "city = @city";
                            comm.Parameters.Add("@city", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.CityIsTooLong, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientStateComboBox":
                        if (currDetail.Value.Length <= PatientSettings.StateMaximumLength)
                        {
                            commandText += "state = @state";
                            comm.Parameters.Add("@state", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.StateIsTooLong, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientZipcodeTextBox":
                        if (DataValidator.IsValidZipCodeFormat(currDetail.Value))
                        {
                            commandText += "zipcode = @zipcode";
                            comm.Parameters.Add("@zipcode", MySqlDbType.String).Value = currDetail.Value;
                            numberOfDetailsChanged++;
                        }
                        else
                        {
                            MessageBox.Show(PatientErrorMessages.ZipcodeMustHaveFiveCharacters, editPatientErrorHeader);
                            return false;
                        }
                        break;
                    case "patientStatusComboBox":
                        commandText += "status = @status";
                        comm.Parameters.Add("@status", MySqlDbType.Int16).Value =
                            currDetail.Value.Equals("True") ? 1 : 0;
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