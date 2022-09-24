using System;
using System.Text.RegularExpressions;
using CS3230Project.ErrorMessages;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    /// The helper class for the Data Access Layer
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        /// Gets the field values
        ///
        /// Precondition None
        /// Postcondition None
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="reader">The sql data reader</param>
        /// <param name="columnOrdinal">The ordinal with the value</param>
        /// <returns></returns>
        public static T GetFieldValueCheckNull<T>(this MySqlDataReader reader, int columnOrdinal)
        {
            T returnValue = default;

            if (!reader[columnOrdinal].Equals(DBNull.Value))
            {
                returnValue = (T)reader[columnOrdinal];
            }
            return returnValue;
        }


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

            var pattern = "\\d{3}-\\d{3}-\\d{4}";
            Regex regex = new Regex(pattern);
            return regex.IsMatch(phoneNumber);
        }
    }
}
