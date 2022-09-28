using System;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    /// <summary>
    /// The helper class for the Data Access Layer
    /// </summary>
    public static class DataHelper
    {
        /// <summary>
        /// Gets the field values
        ///
        /// Precondition None
        /// Postcondition None
        /// </summary>
        /// <typeparam name="T">The type</typeparam>
        /// <param name="reader">The sql data reader</param>
        /// <param name="columnOrdinal">The ordinal with the value</param>
        /// <returns></returns>
        public static T GetFieldValueCheckNull<T>(this MySqlDataReader reader, int columnOrdinal)
        {
            T returnValue = default;

            if (!reader[columnOrdinal].Equals(DBNull.Value))
            {
                returnValue = (T)reader[columnOrdinal];
            }
            return returnValue;
        }
    }
}
