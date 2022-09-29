using CS3230Project.ErrorMessages;
using System;
using System.Text.RegularExpressions;

namespace CS3230Project.Model
{
    /// <summary>
    ///   The Data Validator class.
    /// </summary>
    public static class DataValidator
    {
        private static string validPhoneNumberRegexPattern = "\\d{3}-\\d{3}-\\d{4}";
        private static string validZipCodeRegexPattern = "\\d{5}";

        /// <summary>
        /// Determines whether the provided phone number is in the correct format (XXX-XXX-XXXX).
        /// Precondition:
        ///     phoneNumber != null
        ///     AND phoneNumber.isEmpty() == false
        /// Postcondition: None
        /// </summary>
        /// <param name="phoneNumber">The phone number.</param>
        /// <returns>
        ///   <c>true</c> if [is valid phone number format] [the specified phone number]; otherwise, <c>false</c>.</returns>
        /// <exception cref="System.ArgumentException"></exception>
        public static bool IsValidPhoneNumberFormat(string phoneNumber)
        {
            if (phoneNumber == null)
            {
                throw new ArgumentException(PatientErrorMessages.PhoneNumberCannotBeNull);
            }
            if (phoneNumber.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.PhoneNumberCannotBeEmpty);
            }

            var regex = new Regex(validPhoneNumberRegexPattern);
            return regex.IsMatch(phoneNumber);
        }

        /// <summary>
        /// Determines if the given zip code is in the correct format, five characters all digits
        ///
        /// Precondition:
        ///     zipcode != null
        ///     zipcode.isEmpty() == false
        /// Postcondition: None
        /// </summary>
        /// <param name="zipcode">The zipcode to validate</param>
        /// <returns>True if the zip code is valid, false otherwise</returns>
        /// <exception cref="ArgumentException">If the zip code is null or empty</exception>
        public static bool IsValidZipCodeFormat(string zipcode)
        {
            if (zipcode == null)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeCannotBeNull);
            }
            if (zipcode.Trim().Length == 0)
            {
                throw new ArgumentException(PatientErrorMessages.ZipcodeCannotBeEmpty);
            }

            var regex = new Regex(validZipCodeRegexPattern);
            return regex.IsMatch(zipcode);
        }
    }
}
