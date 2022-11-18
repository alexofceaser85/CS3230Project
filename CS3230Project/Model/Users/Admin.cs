using System;
using CS3230Project.ErrorMessages;
using CS3230Project.Settings;

namespace CS3230Project.Model.Users
{
    /// <summary>
    /// Holds the information for the admins
    /// </summary>
    public class Admin : UserAccount
    {
        /// <summary>
        /// Gets the date of birth of the admin.
        /// </summary>
        /// <value>The date of birth.</value>
        public DateTime DateOfBirth { get; }
        /// <summary>
        /// Gets the gender of the admin.
        /// </summary>
        /// <value>The gender.</value>
        public string Gender { get; }
        /// <summary>
        /// Gets the phone number of the admin.
        /// </summary>
        /// <value>The phone number.</value>
        public string PhoneNumber { get; }
        /// <summary>
        /// Gets the address one of the admin.
        /// </summary>
        /// <value>The address one.</value>
        public string AddressOne { get; }
        /// <summary>
        /// Gets the address two of the admin.
        /// </summary>
        /// <value>The address two.</value>
        public string AddressTwo { get; }
        /// <summary>
        /// Gets the city of the admin.
        /// </summary>
        /// <value>The city.</value>
        public string City { get; }
        /// <summary>
        /// Gets the state of the admin.
        /// </summary>
        /// <value>The state.</value>
        public string State { get; }
        /// <summary>
        /// Gets the zipcode of the admin.
        /// </summary>
        /// <value>The zipcode.</value>
        public string Zipcode { get; }

        /// <summary>
        /// Initializes a new <see cref="Admin"/>
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
        /// <param name="adminId">The admins ID</param>
        /// <param name="firstName">The admins first name</param>
        /// <param name="lastName">The admins last name</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="addressOne">The address one.</param>
        /// <param name="addressTwo">The address two.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipcode">The zipcode.</param>
        public Admin(int adminId, string firstName, string lastName, DateTime dateOfBirth, string gender, string phoneNumber, string addressOne, string addressTwo, string city, string state, string zipcode)
        {
            if (adminId < 0)
            {
                throw new ArgumentException(AdminErrorMessages.IdCannotBeLessThanZero);
            }
            if (firstName == null)
            {
                throw new ArgumentException(AdminErrorMessages.FirstNameCannotBeNull);
            }
            if (firstName.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.FirstNameCannotBeEmpty);
            }
            if (lastName == null)
            {
                throw new ArgumentException(AdminErrorMessages.LastNameCannotBeNull);
            }
            if (lastName.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.LastNameCannotBeEmpty);
            }
            if (dateOfBirth < new DateTime(1900, 1, 1))
            {
                throw new ArgumentException(AdminErrorMessages.DateOfBirthCannotBeBefore1900);
            }
            if (dateOfBirth > DateTime.Now)
            {
                throw new ArgumentException(AdminErrorMessages.DateOfBirthCannotBeInTheFuture);
            }
            if (gender == null)
            {
                throw new ArgumentException(AdminErrorMessages.GenderCannotBeNull);
            }
            if (gender.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.GenderCannotBeEmpty);
            }
            if (gender.Length > UserSettings.GenderMaximumLength)
            {
                throw new ArgumentException(AdminErrorMessages.GenderIsTooLong);
            }
            if (phoneNumber == null)
            {
                throw new ArgumentException(AdminErrorMessages.PhoneNumberCannotBeNull);
            }
            if (phoneNumber.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.PhoneNumberCannotBeEmpty);
            }
            if (!DataValidator.IsValidPhoneNumberFormat(phoneNumber))
            {
                throw new ArgumentException(AdminErrorMessages.InvalidPhoneNumberFormat);
            }
            if (addressOne == null)
            {
                throw new ArgumentException(AdminErrorMessages.AddressOneCannotBeNull);
            }
            if (addressOne.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.AddressOneCannotBeEmpty);
            }
            if (addressOne.Length > UserSettings.AddressComponentMaximumLength)
            {
                throw new ArgumentException(AdminErrorMessages.AddressOneIsTooLong);
            }
            if (city == null)
            {
                throw new ArgumentException(AdminErrorMessages.CityCannotBeNull);
            }
            if (city.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.CityCannotBeEmpty);
            }
            if (city.Length > UserSettings.AddressComponentMaximumLength)
            {
                throw new ArgumentException(AdminErrorMessages.CityIsTooLong);
            }
            if (state == null)
            {
                throw new ArgumentException(AdminErrorMessages.StateCannotBeNull);
            }
            if (state.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.StateCannotBeEmpty);
            }
            if (state.Length > UserSettings.StateMaximumLength)
            {
                throw new ArgumentException(AdminErrorMessages.StateIsTooLong);
            }
            if (zipcode == null)
            {
                throw new ArgumentException(AdminErrorMessages.ZipcodeCannotBeNull);
            }
            if (zipcode.Trim().Length == 0)
            {
                throw new ArgumentException(AdminErrorMessages.ZipcodeCannotBeEmpty);
            }
            if (zipcode.Length < UserSettings.ZipCodeLength)
            {
                throw new ArgumentException(AdminErrorMessages.ZipcodeMustHaveFiveCharacters);
            }
            if (zipcode.Length > UserSettings.ZipCodeLength)
            {
                throw new ArgumentException(AdminErrorMessages.ZipcodeMustHaveFiveCharacters);
            }
            if (!DataValidator.IsValidZipCodeFormat(zipcode))
            {
                throw new ArgumentException(AdminErrorMessages.ZipcodeMustBeAllDigits);
            }

            this.Id = adminId;
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
