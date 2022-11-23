using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model.Visits;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL
{
    public static class AdminVisitsSearchDal
    {

        public static bool GetAllVisitsBetweenDates(DateTime startDate, DateTime endDate)
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();

            const string query = ""; //Add query
            using var command = new MySqlCommand(query, connection);
            //List of objects to return

            //command.Parameters.Add(" ", MySqlDbType....)Value = .....;
            using var reader = command.ExecuteReader();
            //ordinals

            while (reader.Read())
            {
                //build objects and add to the list. 
            }

            return false; //return list
        }

    }
}
