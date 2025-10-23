using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meter_data_management_system.Data.Entity
{
    internal class Service_Centers
    {
        public int    service_id;
        public string service_name;
        public int    meter_id;
        public int    Adress_id;

        string[] centres = { "mumbai", "delhi", "manglore" };

        public void Display_service_centres()
        {
            Console.WriteLine("printing service centres list");
            foreach(var ctr in centres)
            {
                Console.WriteLine(ctr);
            }
        }

        public void InsertServiceCentre(SqlConnection conn)
        {
            Console.WriteLine("----- Insert New Service Centre -----");
            Console.Write("Enter Service Centre ID: ");
            int serviceId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Service Centre Name: ");
            string serviceName = Console.ReadLine();

            Console.Write("Enter Meter ID: ");
            int meterId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Address ID: ");
            int addressId = Convert.ToInt32(Console.ReadLine());

            string query = "INSERT INTO Service_Centers (service_id, service_centre_name, meter_id, Adress_id) " +
                           "VALUES (@sid, @sname, @mid, @aid)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@sid", serviceId);
                cmd.Parameters.AddWithValue("@sname", serviceName);
                cmd.Parameters.AddWithValue("@mid", meterId);
                cmd.Parameters.AddWithValue("@aid", addressId);

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Service Centre inserted successfully!" : "Insertion failed.");
            }
        }

    }
}
