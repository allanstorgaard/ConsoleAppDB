using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppDB
{
    class Program
    {
        static void Main(string[] args)
        {

            string SelectAllStudents = "select * from student";

            //string conn =
            //    "Server=tcp:easj2016100.database.windows.net,1433; Database = HotelDB; Persist Security Info = False; User ID = martin; Password =Pass1234; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;";
            //https://msdn.microsoft.com/en-us/library/system.data.sqlclient.sqlcommand(v=vs.110).aspx

            string conn =
                "Server = tcp:easj2016100.database.windows.net,1433; Initial Catalog = HotelDB; Persist Security Info = False; User ID = martin; Password =Pass1234; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";

            using (SqlConnection databaseConnection = new SqlConnection(conn))
            {
                databaseConnection.Open();
                using (SqlCommand selectCommand = new SqlCommand(SelectAllStudents, databaseConnection))
                {
                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            string klasse = reader.GetString(2);
                            // normally you would not show the ID to the user
                            Console.WriteLine(id + " " + name + " " + name + " " + klasse);
                        }

                    }

                }
            }

            Console.ReadLine();

        }

    }

}
