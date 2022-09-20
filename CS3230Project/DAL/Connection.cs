namespace CS3230Project.DAL
{
    /// <summary>
    /// Holds the connection information
    /// </summary>
    public static class Connection
    {
        private static string databaseName = "cs3230f22a";
        private static string userName = "cs3230f22a";
        private static string password = "Hfd-QzX@hhF[pE!k";
        private static int port = 3306;
        private static string address = "160.10.217.6";

        /// <summary>
        /// The connection string for the database
        /// </summary>
        public static readonly string ConnectionString = $"server={address}; port={port}; " +
                                                         $"uid={userName}; pwd={password}; database={databaseName};";
    }
}
