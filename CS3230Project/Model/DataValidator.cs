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
        private static string regexPattern = "\\d{3}-\\d{3}-\\d{4}";

        /// <summary>
        /// Determines whether the provided phone number is in the correct format (XXX-XXX-XXXX).
        /// Precondition:
        ///     phoneNumber != null
        ///     AND phoneNumber.isEmpty() == false
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

            Regex regex = new Regex(regexPattern);
            return regex.IsMatch(phoneNumber);
        }

    }
}
