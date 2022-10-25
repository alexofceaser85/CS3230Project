using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CS3230Project.Model.Users;
using MySql.Data.MySqlClient;

namespace CS3230Project.DAL.Nurses
{
    public static class NurseDal
    {

        public static List<Nurse> GetNurses()
        {
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select * from nurses";
            using var command = new MySqlCommand(query, connection);

            return NurseDal.createNurses(command);
        }

        public static Nurse GetNurseByID(int ID)
        {
            if (ID < 0)
            {
                throw new ArgumentException(); //TODO: add error message
            }

            Nurse nurse = null;
            using var connection = new MySqlConnection(Connection.ConnectionString);
            connection.Open();
            const string query = "select * from nurses where nurseId = @nurseID";
            using var command = new MySqlCommand(query, connection);
            command.Parameters.Add("@nurseId", MySqlDbType.String).Value = ID;

            using var reader = command.ExecuteReader();
            var nurseIDOrdinal = reader.GetOrdinal("nurseId");
            var employeeIDOrdinal = reader.GetOrdinal("employeeId");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
            var dateOfBirthOrdinal = reader.GetOrdinal("dateOfBirth");
            var genderOrdinal = reader.GetOrdinal("gender");
            var phoneOrdinal = reader.GetOrdinal("phone");
            var addressOneOrdinal = reader.GetOrdinal("addressOne");
            var addressTwoOrdinal = reader.GetOrdinal("addressTwo");
            var cityOrdinal = reader.GetOrdinal("city");
            var stateOrdinal = reader.GetOrdinal("state");
            var zipcodeOrdinal = reader.GetOrdinal("zipcode");

            while (reader.Read())
            {
                nurse = new Nurse(reader.GetInt32(nurseIDOrdinal), reader.GetFieldValueCheckNull<string>(firstNameOrdinal), reader.GetFieldValueCheckNull<string>(lastNameOrdinal), "username");
            }

            return nurse;
        }

        private static List<Nurse> createNurses(MySqlCommand command)
        {
            var nurses = new List<Nurse>();

            using var reader = command.ExecuteReader();
            var nurseIDOrdinal = reader.GetOrdinal("nurseId");
            var employeeIDOrdinal = reader.GetOrdinal("employeeId");
            var firstNameOrdinal = reader.GetOrdinal("firstName");
            var lastNameOrdinal = reader.GetOrdinal("lastName");
            var dateOfBirthOrdinal = reader.GetOrdinal("dateOfBirth");
            var genderOrdinal = reader.GetOrdinal("gender");
            var phoneOrdinal = reader.GetOrdinal("phone");
            var addressOneOrdinal = reader.GetOrdinal("addressOne");
            var addressTwoOrdinal = reader.GetOrdinal("addressTwo");
            var cityOrdinal = reader.GetOrdinal("city");
            var stateOrdinal = reader.GetOrdinal("state");
            var zipcodeOrdinal = reader.GetOrdinal("zipcode");

            while (reader.Read())
            {
                nurses.Add(new Nurse(reader.GetInt32(nurseIDOrdinal), reader.GetFieldValueCheckNull<string>(firstNameOrdinal), reader.GetFieldValueCheckNull<string>(lastNameOrdinal), "username"));
            }

            return nurses;
        }

    }
}
