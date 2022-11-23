using System.Data;
using CS3230Project.Model.Admins;

namespace CS3230Project.ViewModel.Admins
{
    /// <summary>
    /// The view model for the admin service
    /// </summary>
    public static class AdminServiceViewModel
    {
        /// <summary>
        /// Runs an admin query
        /// </summary>
        /// <param name="queryToRun">The admin query to run</param>
        /// <returns>The results of the query</returns>
        public static DataTable RunAdminQuery(string queryToRun)
        {
            return AdminService.RunAdminQuery(queryToRun);
        }
    }
}
