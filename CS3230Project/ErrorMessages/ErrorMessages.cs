namespace CS3230Project.ErrorMessages
{
    /// <summary>
    /// The accounts data access layer error messages
    /// </summary>
    public static class AccountsDalErrorMessages
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

    public static class NurseErrorMessages
    {
        public static string IdCannotBeLessThanZero = "The nurse ID cannot be less than zero";
        public static string FirstNameCannotBeNull = "The nurse first name cannot be null";
        public static string FirstNameCannotBeEmpty = "The nurse first name cannot be empty";
        public static string LastNameCannotBeNull = "The nurse last name cannot be null";
        public static string LastNameCannotBeEmpty = "The nurse last name cannot be empty";
        public static string UserNameCannotBeNull = "The nurse user name cannot be null";
        public static string UserNameCannotBeEmpty = "The nurse user name cannot be empty";
    }
}
