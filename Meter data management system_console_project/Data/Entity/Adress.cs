using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meter_data_management_system.Data.Entity
{
    internal class Adress
    {
        
        public void Insertadress(SqlConnection conn)
        {
            Console.Write("Entering adress details...");

            Console.WriteLine("enter adress id");
            int Adress_id1 = int.Parse(Console.ReadLine());

            Console.WriteLine("enter the adress name ");
            string Adress_name1 = Console.ReadLine();

            string query = "INSERT INTO Adress (Adress_id, Adress_name) VALUES (@Adress_id, @Adress_name)";

            using (SqlCommand cm = new SqlCommand(query, conn))
            {
                cm.Parameters.AddWithValue("@Adress_id", Adress_id1);
                cm.Parameters.AddWithValue("@Adress_name", Adress_name1);

                int rows = cm.ExecuteNonQuery();
                if (rows > 0)
                {
                    Console.WriteLine("Inserted record successfully!");
                }
                else
                {
                    Console.WriteLine("No record inserted.");
                }
            }

        }

    }
}



