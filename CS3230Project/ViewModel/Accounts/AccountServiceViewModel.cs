using CS3230Project.Model.Accounts.Services;

namespace CS3230Project.ViewModel.Accounts
{
    /// <summary>
    /// The view model for the account service
    /// </summary>
    public static class AccountServiceViewModel
    {
        /// <summary>
        /// Logs a user into the system
        ///
        /// Precondition: None
        /// Postcondition: The user is logged in
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static bool Login(string username, string password)
        {
            return AccountService.Login(username, password);
        }
    }
}
