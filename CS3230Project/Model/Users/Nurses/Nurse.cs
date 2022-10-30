using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Settings;

namespace CS3230Project.Model.Users
{
    /// <summary>
    /// Holds the information for the nurses
    /// </summary>
    public class Nurse
    {
        /// <summary>
        /// The ID for the nurse
        /// </summary>
        public int NurseId { get; }
        /// <summary>
        /// The first name for the nurse
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// The last name for the nurse
        /// </summary>
        public string LastName { get; }
        /// <summary>
        /// Gets the date of birth of the nurse.
        /// </summary>
        /// <value>The date of birth.</value>
        public DateTime DateOfBirth { get; }
        /// <summary>
        /// Gets the gender of the nurse.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get; }
        /// <summary>
        /// Gets the phone number of the nurse.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; }
        /// <summary>
        /// Gets the address one of the nurse.
        /// </summary>
        /// <value>The address one.</value>
        public string AddressOne { get; }
        /// <summary>
        /// Gets the address two of the nurse.
        /// </summary>
        /// <value>The address two.</value>
        public string AddressTwo { get; }
        /// <summary>
        /// Gets the city of the nurse.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; }
        /// <summary>
        /// Gets the state of the nurse.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; }
        /// <summary>
        /// Gets the zipcode of the nurse.
        /// </summary>
        /// <value>The zipcode.</value>
        public string Zipcode { get; }
        /// <summary>
        /// The user name for the nurse
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Initializes a new <see cref="Nurse"/>
        ///
        /// Precondition:
        ///     nurseId >= 0
        ///     AND firstName != null
        ///     AND firstName.isEmpty() == false
        ///     AND lastName != null
        ///     AND lastName.isEmpty() == false
        ///     AND dateOfBirth MORE THAN 1900-01-01
        ///     AND dateOfBirth LESS THAN Today's Date
        ///     AND gender != null
        ///     AND gender.isEmpty() == false
        ///     AND addressOne != null
        ///     AND addressOne.isEmpty() == false
        ///     AND city != null
        ///     AND city.isEmpty() == false
        ///     AND state != null
        ///     AND state.isEmpty() == false
        ///     AND zipcode != null
        ///     AND zipcode.isEmpty() == false
        ///     AND phoneNumber != null
        ///     AND phoneNumber.isEmpty() == false
        /// </summary>
        /// <param name="nurseId">The nurses ID</param>
        /// <param name="firstName">The nurses first name</param>
        /// <param name="lastName">The nurses last name</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="addressOne">The address one.</param>
        /// <param name="addressTwo">The address two.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipcode">The zipcode.</param>
        public Nurse(int nurseId, string firstName, string lastName, DateTime dateOfBirth, string gender, string phoneNumber, string addressOne, string addressTwo, string city, string state, string zipcode)
        {
            if (nurseId < 0)
            {
                throw new ArgumentException(NurseErrorMessages.IdCannotBeLessThanZero);
            }
            if (firstName == null)
            {
                throw new ArgumentException(NurseErrorMessages.FirstNameCannotBeNull);
            }
            if (firstName.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.FirstNameCannotBeEmpty);
            }
            if (lastName == null)
            {
                throw new ArgumentException(NurseErrorMessages.LastNameCannotBeNull);
            }
            if (lastName.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.LastNameCannotBeEmpty);
            }
            if (dateOfBirth < new DateTime(1900, 1, 1))
            {
                throw new ArgumentException(NurseErrorMessages.DateOfBirthCannotBeBefore1900);
            }
            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(NurseErrorMessages.DateOfBirthCannotBeInTheFuture);
            }
            if (gender == null)
            {
                throw new ArgumentException(NurseErrorMessages.GenderCannotBeNull);
            }
            if (gender.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.GenderCannotBeEmpty);
            }
            if (gender.Length > UserSettings.GenderMaximumLength)
            {
                throw new ArgumentException(NurseErrorMessages.GenderIsTooLong);
            }
            if (phoneNumber == null)
            {
                throw new ArgumentException(NurseErrorMessages.PhoneNumberCannotBeNull);
            }
            if (phoneNumber.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.PhoneNumberCannotBeEmpty);
            }
            if (!DataValidator.IsValidPhoneNumberFormat(phoneNumber))
            {
                throw new ArgumentException(NurseErrorMessages.InvalidPhoneNumberFormat);
            }
            if (addressOne == null)
            {
                throw new ArgumentException(NurseErrorMessages.AddressOneCannotBeNull);
            }
            if (addressOne.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.AddressOneCannotBeEmpty);
            }
            if (addressOne.Length > UserSettings.AddressComponentMaximumLength)
            {
                throw new ArgumentException(NurseErrorMessages.AddressOneIsTooLong);
            }
            if (city == null)
            {
                throw new ArgumentException(NurseErrorMessages.CityCannotBeNull);
            }
            if (city.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.CityCannotBeEmpty);
            }
            if (city.Length > UserSettings.AddressComponentMaximumLength)
            {
                throw new ArgumentException(NurseErrorMessages.CityIsTooLong);
            }
            if (state == null)
            {
                throw new ArgumentException(NurseErrorMessages.StateCannotBeNull);
            }
            if (state.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.StateCannotBeEmpty);
            }
            if (state.Length > Settings.UserSettings.StateMaximumLength)
            {
                throw new ArgumentException(NurseErrorMessages.StateIsTooLong);
            }
            if (zipcode == null)
            {
                throw new ArgumentException(NurseErrorMessages.ZipcodeCannotBeNull);
            }
            if (zipcode.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.ZipcodeCannotBeEmpty);
            }
            if (zipcode.Length < UserSettings.ZipCodeLength)
            {
                throw new ArgumentException(NurseErrorMessages.ZipcodeMustHaveFiveCharacters);
            }
            if (zipcode.Length > UserSettings.ZipCodeLength)
            {
                throw new ArgumentException(NurseErrorMessages.ZipcodeMustHaveFiveCharacters);
            }
            if (!DataValidator.IsValidZipCodeFormat(zipcode))
            {
                throw new ArgumentException(NurseErrorMessages.ZipcodeMustBeAllDigits);
            }

            this.NurseId = nurseId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.PhoneNumber = phoneNumber;
            this.AddressOne = addressOne;
            this.AddressTwo = addressTwo;
            this.City = city;
            this.State = state;
            this.Zipcode = zipcode;
            this.UserName = "";
        }
    }
}
