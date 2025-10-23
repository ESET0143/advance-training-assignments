using System.Data.SqlClient;

namespace Meter_data_management_system.Data.Entity
{
    internal class Customer
    {
        
        public  void InsertCustomer(SqlConnection conn)
        {
            Console.WriteLine("----- Insert New Customer -----");
            Console.Write("Enter Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Address ID: ");
            int addressId = Convert.ToInt32(Console.ReadLine());

            string query = "INSERT INTO Customer (customerid, customername, Adress_id) VALUES (@cid, @cname, @aid)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cid", customerId);
                cmd.Parameters.AddWithValue("@cname", customerName);
                cmd.Parameters.AddWithValue("@aid", addressId);

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Customer inserted successfully!" : "Insertion failed.");
            }
        }

        public void DisplayMyFullProfile(SqlConnection conn, int customerId)
        {
            string query = @"
        SELECT 
            c.customerid, c.customername,
            a.Adress_name,
            m.meter_id, m.connection_date, m.warranty_date,
            b.billing_id, b.billed_units, b.price, b.dueAmount, b.bill_start_date, b.bill_end_date, b.billing_state,
            sc.service_centre_name, sc.service_id
        FROM Customer c
        LEFT JOIN Adress a ON c.Adress_id = a.Adress_id
        LEFT JOIN Meters m ON c.customerid = m.customer_id
        LEFT JOIN Billing b ON c.customerid = b.customer_id
        LEFT JOIN Service_Centers sc ON m.meter_id = sc.meter_id
        WHERE c.customerid = @cid
    ";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cid", customerId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            // Customer Info
                            int cid = Convert.ToInt32(reader["customerid"]);
                            string cname = reader["customername"].ToString();
                            string address = reader["Adress_name"].ToString();

                            // Meter Info
                            int meterId = reader["meter_id"] != DBNull.Value ? Convert.ToInt32(reader["meter_id"]) : 0;
                            DateTime connectionDate = reader["connection_date"] != DBNull.Value ? Convert.ToDateTime(reader["connection_date"]) : DateTime.MinValue;
                            DateTime warrantyDate = reader["warranty_date"] != DBNull.Value ? Convert.ToDateTime(reader["warranty_date"]) : DateTime.MinValue;

                            // Billing Info
                            int billingId = reader["billing_id"] != DBNull.Value ? Convert.ToInt32(reader["billing_id"]) : 0;
                            int billedUnits = reader["billed_units"] != DBNull.Value ? Convert.ToInt32(reader["billed_units"]) : 0;
                            int price = reader["price"] != DBNull.Value ? Convert.ToInt32(reader["price"]) : 0;
                            int dueAmount = reader["dueAmount"] != DBNull.Value ? Convert.ToInt32(reader["dueAmount"]) : 0;
                            string billState = reader["billing_state"] != DBNull.Value ? reader["billing_state"].ToString() : "N/A";

                            // Service Centre Info
                            string serviceCentre = reader["service_centre_name"] != DBNull.Value ? reader["service_centre_name"].ToString() : "N/A";

                            // Display the profile
                            Console.WriteLine($"Customer: {cname} (ID: {cid})");
                            Console.WriteLine($"Address: {address}");
                            Console.WriteLine($"Meter: {meterId}, Connection: {connectionDate:d}, Warranty: {warrantyDate:d}");
                            Console.WriteLine($"Billing: {billingId}, Units: {billedUnits}, Price: {price}, Due: {dueAmount}, Status: {billState}");
                            Console.WriteLine($"Service Centre: {serviceCentre}");
                            Console.WriteLine(new string('-', 50));
                        }
                    }
                    else
                    {
                        Console.WriteLine("No customer found with that ID.");
                    }
                }
            }
        }
    }
}
