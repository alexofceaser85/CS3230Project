using CS3230Project.Model.Accounts;

namespace CS3230Project.Model.Users
{
    /// <summary>
    /// Holds common info for a user account
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// The user name for the nurse
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// The user Id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// The user first name
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// The user last name
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// The user account type
        /// </summary>
        public AccountType AccountType { get; set; }
    }
}
