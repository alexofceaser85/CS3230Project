using CS3230Project.Model.Users;

namespace CS3230Project.Model.Accounts
{
    /// <summary>
    /// Holds the currently logged in user
    /// </summary>
    public static class CurrentUser
    {
        /// <summary>
        /// The currently logged in user
        /// </summary>
        public static UserAccount User { get; set; }
    }
}
