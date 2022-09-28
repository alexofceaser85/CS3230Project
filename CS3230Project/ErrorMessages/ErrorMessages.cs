namespace CS3230Project.ErrorMessages
{
    /// <summary>
    /// The accounts data access layer error messages
    /// </summary>
    public static class AccountsErrorMessages
    {
        /// <summary>
        /// Error message for null login user name
        /// </summary>
        public static string LoginUserNameCannotBeNull = "The login user name cannot be null";
        /// <summary>
        /// Error message for empty login user name
        /// </summary>
        public static string LoginUserNameCannotBeEmpty = "The login user name cannot be empty";
        /// <summary>
        /// Error message for null login password
        /// </summary>
        public static string LoginPasswordCannotBeNull = "The login password cannot be null";
        /// <summary>
        /// Error message for empty login password
        /// </summary>
        public static string LoginPasswordCannotBeEmpty = "The login password cannot be empty";
    }

    /// <summary>
    /// The error messages for the nurse
    /// </summary>
    public static class NurseErrorMessages
    {
        /// <summary>
        /// Error message for id less than zero
        /// </summary>
        public static string IdCannotBeLessThanZero = "The nurse ID cannot be less than zero";
        /// <summary>
        /// Error message for null first name
        /// </summary>
        public static string FirstNameCannotBeNull = "The nurse first name cannot be null";
        /// <summary>
        /// Error message for empty first name
        /// </summary>
        public static string FirstNameCannotBeEmpty = "The nurse first name cannot be empty";
        /// <summary>
        /// Error message for null last name
        /// </summary>
        public static string LastNameCannotBeNull = "The nurse last name cannot be null";
        /// <summary>
        /// Error message for empty last name
        /// </summary>
        public static string LastNameCannotBeEmpty = "The nurse last name cannot be empty";
        /// <summary>
        /// Error message for null user name
        /// </summary>
        public static string UserNameCannotBeNull = "The nurse user name cannot be null";
        /// <summary>
        /// Error message for empty user name
        /// </summary>
        public static string UserNameCannotBeEmpty = "The nurse user name cannot be empty";
    }

    /// <summary>
    ///   The error messages for the patient
    /// </summary>
    public static class PatientErrorMessages
    {
        /// <summary>
        /// Error message for id less than zero
        /// </summary>
        public static string PatientIdCannotBeLessThanZero = "The patient ID cannot be less than zero";
        /// <summary>
        /// Error message for null first name
        /// </summary>
        public static string FirstNameCannotBeNull = "The patient first name cannot be null";
        /// <summary>
        /// Error message for empty first name
        /// </summary>
        public static string FirstNameCannotBeEmpty = "The patient first name cannot be empty";
        /// <summary>
        /// Error message for null last name
        /// </summary>
        public static string LastNameCannotBeNull = "The patient last name cannot be null";
        /// <summary>
        /// Error message for empty last name
        /// </summary>
        public static string LastNameCannotBeEmpty = "The patient last name cannot be empty";
        /// <summary>
        /// Error message for both first and last names being either null or empty
        /// </summary>
        public static string FirstAndLastNamesCannotBothBeEmpty =
            "The patients first and last names cannot both be empty.";
        /// <summary>
        /// Error message for date of birth before 1900
        /// </summary>
        public static string DateOfBirthCannotBeBefore1900 = "The patient date of birth cannot be before 1900.";
        /// <summary>
        /// Error message for date of birth in the future
        /// </summary>
        public static string DateOfBirthCannotBeInTheFuture = "The patient date of birth cannot be in the future.";
        /// <summary>
        /// Error message for null gender
        /// </summary>
        public static string GenderCannotBeNull = "The patient gender cannot be null.";
        /// <summary>
        /// Error message for empty gender
        /// </summary>
        public static string GenderCannotBeEmpty = "The patient gender cannot be empty.";
        /// <summary>
        /// Error message for null street address
        /// </summary>
        public static string AddressOneCannotBeNull = "The patient address one cannot be null.";
        /// <summary>
        /// Error message for empty street address
        /// </summary>
        public static string AddressOneCannotBeEmpty = "The patient address one cannot be empty.";
        /// <summary>
        /// Error message for null city
        /// </summary>
        public static string CityCannotBeNull = "The patient city cannot be null.";
        /// <summary>
        /// Error message for empty city
        /// </summary>
        public static string CityCannotBeEmpty = "The patient city cannot be empty.";
        /// <summary>
        /// Error message for null state
        /// </summary>
        public static string StateCannotBeNull = "The patient state cannot be null.";
        /// <summary>
        /// Error message for empty state
        /// </summary>
        public static string StateCannotBeEmpty = "The patient state cannot be empty.";
        /// <summary>
        /// Error message for null zip
        /// </summary>
        public static string ZipcodeCannotBeNull = "The patient zip code cannot be null.";
        /// <summary>
        /// Error message for empty zip
        /// </summary>
        public static string ZipcodeCannotBeEmpty = "The patient zip code cannot be empty.";
        /// <summary>
        /// Error message for null phone number
        /// </summary>
        public static string PhoneNumberCannotBeNull = "The patient phone number cannot be null.";
        /// <summary>
        /// Error message for empty phone number
        /// </summary>
        public static string PhoneNumberCannotBeEmpty = "The patient phone number cannot be empty.";
        /// <summary>
        /// Error message for an invalid phone number format
        /// </summary>
        public static string InvalidPhoneNumberFormat =
            "The provided phone number is not in the correct format (XXX-XXX-XXXX)";
        /// <summary>
        /// Error message for a null patient to add
        /// </summary>
        public static string PatientToAddCannotBeNull = "The patient to add cannot be null.";
    }
}
