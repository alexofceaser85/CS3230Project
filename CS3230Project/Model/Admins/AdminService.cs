using System;
using System.Data;
using CS3230Project.DAL.Admins;
using CS3230Project.ErrorMessages;

namespace CS3230Project.Model.Admins
{
    /// <summary>
    /// The service for the admins
    /// </summary>
    public static class AdminService
    {
        /// <summary>
        /// Runs an admin query
        ///
        /// Precondition: queryToRun.Length != 0
        /// Postcondition: None
        /// </summary>
        /// <param name="queryToRun">The query to run</param>
        /// <returns>The results of the query</returns>
        public static DataTable RunAdminQuery(string queryToRun)
        {
            if (queryToRun.Trim().Length == 0)
            {
                throw new ArgumentException(AdminServiceErrorMessages.AdminQueryToRunCannotBeEmpty);
            }
            return AdminsDAL.RunAdminQuery(queryToRun);
        }
    }
}
