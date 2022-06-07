using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ReadingDataFromDb
{
    public class Example
    {
        private readonly string _connectionString = "Server=(localdb)\\studia;Database=Data;Trusted_Connection=True;";

        protected  SqlConnection Connection { get; set; }

        public Example()
        {
            Connection = new SqlConnection(_connectionString);
        }

        public string GetValues(int id)
        {
            using (SqlCommand cmd = Connection.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT [Name], [Surname] from [dbo].[Employees] Where [Id] = @Id;";
                cmd.Parameters.AddWithValue(@"Id", id);
                cmd.Connection.Open();

                using (var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    var surname = "";
                    while (reader.Read())
                    {
                        surname = reader["Surname"].ToString();
                    }

                    return surname;
                }
            }
        }
    }
}
