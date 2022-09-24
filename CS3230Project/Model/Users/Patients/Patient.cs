using System;
using CS3230Project.DAL;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Users.Patients
{
    /// <summary>
    /// Holds the information for a patient
    /// </summary>
    public class Patient
    {

        /// <summary>
        /// The ID for the patient
        /// </summary>
        public int PatientId { get; }

        /// <summary>
        /// The first name for the patient
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// The last name for the patient
        /// </summary>
        public string LastName { get; }

        /// <summary>
        /// The date of birth for the patient
        /// </summary>
        public DateTime DateOfBirth { get; }

        /// <summary>
        /// The gender of the patient
        /// </summary>
        public string Gender { get; }

        /// <summary>
        /// The address one for the patient
        /// </summary>
        public string AddressOne { get; }

        /// <summary>
        /// The address two for the patient
        /// </summary>
        public string AddressTwo { get; }

        /// <summary>
        /// The city for the patient
        /// </summary>
        public string City { get; }

        /// <summary>
        /// The state for the patient
        /// </summary>
        public string State { get; }

        /// <summary>
        /// The zipcode for the patient
        /// </summary>
        public string Zipcode { get; }

        /// <summary>
        /// The phone number for the patient
        /// </summary>
        public string PhoneNumber { get; }

        /// <summary>
        /// The status status for the patient
        /// </summary>
        public bool Status { get; }




        /// <summary>
        /// Initializes a new instance of the <see cref="Patient" />
        ///
        /// Precondition:
        ///     patientId >= 0
        ///     AND firstName != null
        ///     AND firstName.isEmpty() == false
        ///     AND lastName != null
        ///     AND lastName.isEmpty() == false
        ///     AND dateOfBirth > DateTime(1900, 1, 1)
        ///     AND dateOfBirth < DateTime.Now()
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
        /// <param name="patientId">The identifier.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="dateOfBirth">The date of birth.</param>
        /// <param name="gender">The gender.</param>
        /// <param name="addressOne">The address one.</param>
        /// <param name="addressTwo">The address two.</param>
        /// <param name="city">The city.</param>
        /// <param name="state">The state.</param>
        /// <param name="zipcode">The zipcode.</param>
        /// <param name="phoneNumber">The phone number.</param>
        /// <param name="status">if set to <c>true</c> [status].</param>
        /// <exception cref="System.ArgumentException"></exception>
        public Patient(int patientId, string firstName, string lastName, DateTime dateOfBirth, string gender,
            string addressOne, string addressTwo, string city, string state, string zipcode, string phoneNumber, bool status)
        {
            if (patientId < 0)
            {
                throw new ArgumentException(PatientErrorMessages.PatientIdCannotBeLessThanZero);
            }
            if (firstName == null)
            {
                throw new ArgumentException(PatientErrorMessages.FirstNameCannotBeNull);
            }
            if (firstName.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.FirstNameCannotBeEmpty);
            }
            if (lastName == null)
            {
                throw new ArgumentException(PatientErrorMessages.LastNameCannotBeNull);
            }
            if (lastName.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.LastNameCannotBeEmpty);
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
            if (addressOne == null)
            {
                throw new ArgumentException(PatientErrorMessages.AddressOneCannotBeNull);
            }
            if (addressOne.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.AddressOneCannotBeEmpty);
            }
            if (city == null)
            {
                throw new ArgumentException(PatientErrorMessages.CityCannotBeNull);
            }
            if (city.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.CityCannotBeEmpty);
            }
            if (state == null)
            {
                throw new ArgumentException(PatientErrorMessages.StateCannotBeNull);
            }
            if (state.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.StateCannotBeEmpty);
            }
            if (zipcode == null)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeCannotBeNull);
            }
            if (zipcode.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeCannotBeEmpty);
            }
            if (phoneNumber == null)
            {
                throw new ArgumentException(PatientErrorMessages.PhoneNumberCannotBeNull);
            }
            if (phoneNumber.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.PhoneNumberCannotBeEmpty);
            }
            if (!DataHelper.IsValidPhoneNumberFormat(phoneNumber))
            {
                throw new FormatException(PatientErrorMessages.InvalidPhoneNumberFormat);
            }

            this.PatientId = patientId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.DateOfBirth = dateOfBirth;
            this.Gender = gender;
            this.AddressOne = addressOne;
            this.AddressTwo = addressTwo;
            this.City = city;
            this.State = state;
            this.Zipcode = zipcode;
            this.PhoneNumber = phoneNumber;
            this.Status = status;
        }

    }
}
