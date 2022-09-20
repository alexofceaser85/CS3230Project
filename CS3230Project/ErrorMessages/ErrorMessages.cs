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
}
