using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace Meter_data_management_system.Data.Entity
{
    internal class meters
    {
        public int meter_id;
        public string type_of_meter;
        public string warranty_date;

        //public meters(int m_id, string type_meter, string w_date)
        //{
        //    meter_id = m_id;
        //    type_of_meter = type_meter;
        //    warranty_date = w_date;
        //}

        // Method to display meter info

        public void InsertMeter(SqlConnection conn)
        {
            Console.WriteLine("----- Insert New Meter -----");
            Console.Write("Enter Meter ID: ");
            int meterId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Warranty Date (yyyy-MM-dd): ");
            DateTime warrantyDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Connection Date (yyyy-MM-dd): ");
            DateTime connectionDate = DateTime.Parse(Console.ReadLine());

            string query = "INSERT INTO Meters (meter_id, customer_id, warranty_date, connection_date) VALUES (@mid, @cid, @wdate, @cdate)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@mid", meterId);
                cmd.Parameters.AddWithValue("@cid", customerId);
                cmd.Parameters.AddWithValue("@wdate", warrantyDate);
                cmd.Parameters.AddWithValue("@cdate", connectionDate);

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Meter inserted successfully!" : "Insertion failed.");
            }
        }

        public void ShowMeter()
        {
            Console.WriteLine($"Meter ID: {meter_id}, Type: {type_of_meter}, Warranty: {warranty_date}");
        }
    }
}
