using System.Data;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Admins
{
    /// <summary>
    /// The data access layer for the admins
    /// </summary>
    public static class AdminsDAL
    {
        /// <summary>
        /// Runs an admin query
        /// </summary>
        /// <param name="queryToRun">The admin query to run</param>
        /// <returns></returns>
        public static DataTable RunAdminQuery(string queryToRun)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            using var command = new MySqlCommand(queryToRun, connection);

            var dataAdapter = new MySqlDataAdapter(command);
            var results = new DataTable();
            dataAdapter.Fill(results);

            return results;
        }
    }
}
