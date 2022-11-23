using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Settings;

namespace CS3230Project.Model.Users.Patients
{
    /// <summary>
    ///     Holds the information for a patient
    /// </summary>
    public class Patient
    {
        /// <summary>
        ///     The ID for the patient
        /// </summary>
        public int PatientId { get; }

        /// <summary>
        /// The last name for the patient
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// The first name for the patient
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        ///     The date of birth for the patient
        /// </summary>
        public DateTime DateOfBirth { get; }

        /// <summary>
        ///     The gender of the patient
        /// </summary>
        public string Gender { get; }

        /// <summary>
        ///     The address one for the patient
        /// </summary>
        public string AddressOne { get; }

        /// <summary>
        ///     The address two for the patient
        /// </summary>
        public string AddressTwo { get; }

        /// <summary>
        ///     The city for the patient
        /// </summary>
        public string City { get; }

        /// <summary>
        ///     The state for the patient
        /// </summary>
        public string State { get; }

        /// <summary>
        ///     The zipcode for the patient
        /// </summary>
        public string Zipcode { get; }

        /// <summary>
        ///     The phone number for the patient
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        ///     The isActive isActive for the patient
        /// </summary>
        public bool IsActive { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Patient" />
        /// Precondition:
        ///     patientId MORE THAN OR EQUAL TO 0
        ///     AND lastName != null
        ///     AND lastName.isEmpty() == false
        ///     AND firstName != null
        ///     AND firstName.isEmpty() == false
        ///     AND dateOfBirth MORE THAN 1900-01-01
        ///     AND dateOfBirth LESS THAN Today's Date
        ///     AND gender != null
        ///     AND gender.isEmpty() == false
        ///     AND addressOne != null
        ///     AND addressOne.isEmpty() == false
        ///     AND addressTwo != null
        ///     AND city != null
        ///     AND city.isEmpty() == false
        ///     AND state != null
        ///     AND state.isEmpty() == false
        ///     AND zipcode != null
        ///     AND zipcode.isEmpty() == false
        ///     AND phoneNumber != null
        ///     AND phoneNumber.isEmpty() == false
        /// </summary>
        /// <param name="patientId">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="addressOne">The address one.</param>
        /// <param name="addressTwo">The address two.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipcode">The zipcode.</param>
        /// <param name="isActive">if set to <c>true</c> [isActive].</param>
        /// <exception cref="System.ArgumentException"></exception>
        public Patient(int patientId, string lastName, string firstName, DateTime dateOfBirth, string gender, string phoneNumber,
            string addressOne, string addressTwo, string city, string state, string zipcode, bool isActive)
        {
            if (patientId < 0)
            {
                throw new ArgumentException(PatientErrorMessages.PatientIdCannotBeLessThanZero);
            }
            if (lastName == null)
            {
                throw new ArgumentException(PatientErrorMessages.LastNameCannotBeNull);
            }
            if (lastName.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.LastNameCannotBeEmpty);
            }
            if (lastName.Length > UserSettings.NameMaximumLength)
            {
                throw new ArgumentException(PatientErrorMessages.LastNameIsTooLong);
            }
            if (firstName == null)
            {
                throw new ArgumentException(PatientErrorMessages.FirstNameCannotBeNull);
            }
            if (firstName.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.FirstNameCannotBeEmpty);
            }
            if (firstName.Length > UserSettings.NameMaximumLength)
            {
                throw new ArgumentException(PatientErrorMessages.FirstNameIsTooLong);
            }
            if (dateOfBirth < new DateTime(1900, 1, 1))
            {
                throw new ArgumentException(PatientErrorMessages.DateOfBirthCannotBeBefore1900);
            }
            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(PatientErrorMessages.DateOfBirthCannotBeInTheFuture);
            }
            if (gender == null)
            {
                throw new ArgumentException(PatientErrorMessages.GenderCannotBeNull);
            }
            if (gender.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.GenderCannotBeEmpty);
            }
            if (gender.Length > UserSettings.GenderMaximumLength)
            {
                throw new ArgumentException(PatientErrorMessages.GenderIsTooLong);
            }
            if (phoneNumber == null)
            {
                throw new ArgumentException(PatientErrorMessages.PhoneNumberCannotBeNull);
            }
            if (phoneNumber.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.PhoneNumberCannotBeEmpty);
            }
            if (!DataValidator.IsValidPhoneNumberFormat(phoneNumber))
            {
                throw new ArgumentException(PatientErrorMessages.InvalidPhoneNumberFormat);
            }
            if (addressOne == null)
            {
                throw new ArgumentException(PatientErrorMessages.AddressOneCannotBeNull);
            }
            if (addressOne.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.AddressOneCannotBeEmpty);
            }
            if (addressOne.Length > UserSettings.AddressComponentMaximumLength)
            {
                throw new ArgumentException(PatientErrorMessages.AddressOneIsTooLong);
            }
            if (addressTwo == null)
            {
                throw new ArgumentException(PatientErrorMessages.AddressTwoCannotBeNull);
            }
            if (addressTwo.Length > UserSettings.AddressComponentMaximumLength)
            {
                throw new ArgumentException(PatientErrorMessages.AddressTwoIsTooLong);
            }
            if (city == null)
            {
                throw new ArgumentException(PatientErrorMessages.CityCannotBeNull);
            }
            if (city.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.CityCannotBeEmpty);
            }
            if (city.Length > UserSettings.AddressComponentMaximumLength)
            {
                throw new ArgumentException(PatientErrorMessages.CityIsTooLong);
            }
            if (state == null)
            {
                throw new ArgumentException(PatientErrorMessages.StateCannotBeNull);
            }
            if (state.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.StateCannotBeEmpty);
            }
            if (state.Length > 50)
            {
                throw new ArgumentException(PatientErrorMessages.StateIsTooLong);
            }
            if (zipcode == null)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeCannotBeNull);
            }
            if (zipcode.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeCannotBeEmpty);
            }
            if (zipcode.Length < UserSettings.ZipCodeLength)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeMustHaveFiveCharacters);
            }
            if (zipcode.Length > UserSettings.ZipCodeLength)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeMustHaveFiveCharacters);
            }
            if (!DataValidator.IsValidZipCodeFormat(zipcode))
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeMustBeAllDigits);
            }

            this.PatientId = patientId;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.AddressOne = addressOne;
            this.AddressTwo = addressTwo;
            this.City = city;
            this.State = state;
            this.Zipcode = zipcode;
            this.PhoneNumber = phoneNumber;
            this.IsActive = isActive;
        }
    }
}