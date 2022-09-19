using System;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Accounts.Users
{
    /// <summary>
    /// Holds the information for the nurses
    /// </summary>
    public class Nurse
    {
        /// <summary>
        /// The ID for the nurse
        /// </summary>
        public int Id { get; }
        /// <summary>
        /// The first name for the nurse
        /// </summary>
        public string FirstName { get; }
        /// <summary>
        /// The last name for the nurse
        /// </summary>
        public string LastName { get; }
        /// <summary>
        /// The user name for the nurse
        /// </summary>
        public string UserName { get; }

        /// <summary>
        /// Initializes a new <see cref="Nurse"/>
        ///
        /// Precondition:
        ///     id >= 0
        ///     AND firstName != null
        ///     AND firstName.isEmpty() == false
        ///     AND lastName != null
        ///     AND lastName.isEmpty() == false
        ///     AND userName != null
        ///     AND userName.isEmpty() == false
        /// </summary>
        /// <param name="id">The nurses ID</param>
        /// <param name="firstName">The nurses first name</param>
        /// <param name="lastName">The nurses last name</param>
        /// <param name="userName">The nurses user name</param>
        public Nurse(int id, string firstName, string lastName, string userName)
        {
            if (id < 0)
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
            if (userName == null)
            {
                throw new ArgumentException(NurseErrorMessages.UserNameCannotBeNull);
            }
            if (userName.Trim().Length == 0)
            {
                throw new ArgumentException(NurseErrorMessages.UserNameCannotBeEmpty);
            }

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            UserName = userName;
        }
    }
}
