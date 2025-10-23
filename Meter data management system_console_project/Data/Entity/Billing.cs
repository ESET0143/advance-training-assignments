using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meter_data_management_system.Data.Entity
{
    internal class Billing
    {
        public int billing_id;
        public int billed_units;
        public int meter_id;
        public int price;
        public int dueAmount;
        public string bill_start_date;
        public string bill_end_date;
        public string bill_generated_date;
        public string due_date;

        public void displayUpCommingBilllingsWithCid(SqlConnection conn, int customerId)
        {
            string query = "SELECT * FROM Billing WHERE (customer_id = " + customerId + " ) and due_date<GETDATE()";
            using (SqlCommand cm = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cm.ExecuteReader())
                {


                    Console.WriteLine("--------billing of this month -------- :");
                    int i = 0;
                    while (reader.Read())
                    {
                        // Read each column from the data reader
                        int billing_id = Convert.ToInt32(reader["billing_id"]);
                        int billed_units = Convert.ToInt32(reader["billed_units"]);
                        int meter_id = Convert.ToInt32(reader["meter_id"]);
                        decimal price = Convert.ToInt32(reader["price"]);
                        decimal dueAmount = Convert.ToInt32(reader["dueAmount"]);
                        DateTime bill_start_date = Convert.ToDateTime(reader["bill_start_date"]);
                        DateTime bill_end_date = Convert.ToDateTime(reader["bill_end_date"]);
                        DateTime bill_generated_date = Convert.ToDateTime(reader["bill_generated_date"]);
                        DateTime due_date = Convert.ToDateTime(reader["due_date"]);
                        int customer_id = Convert.ToInt32(reader["customer_id"]);
                        string billing_state = reader["billing_state"].ToString();

                        // Display or process the data
                        Console.WriteLine($"{++i}: Billing ID = {billing_id}, Units = {billed_units}, Meter ID = {meter_id}, Price = {price:C}, Due Amount = {dueAmount:C},");
                        //Console.WriteLine($"    Start: {bill_start_date:d}, End: {bill_end_date:d}, Generated: {bill_generated_date:d}, Due: {due_date:d}");
                        //Console.WriteLine($"    Customer ID = {customer_id}, State = {billing_state}");
                        Console.WriteLine("----------------------------------------------------");
                    }
                    if (i == 0)
                    {
                        Console.WriteLine("no customer with that id");
                    }
                }
            }

        }
        public void displayBilllingsWithCid(SqlConnection conn, int customerId)
        {
            string query = "SELECT * FROM Billing WHERE customer_id = " + customerId;

            using (SqlCommand cm = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cm.ExecuteReader())
                {


                    Console.WriteLine("--------billing of this month -------- :");
                    int i = 0;
                    while (reader.Read())
                    {
                        // Read each column from the data reader
                        int billing_id = Convert.ToInt32(reader["billing_id"]);
                        int billed_units = Convert.ToInt32(reader["billed_units"]);
                        int meter_id = Convert.ToInt32(reader["meter_id"]);
                        decimal price = Convert.ToInt32(reader["price"]);
                        decimal dueAmount = Convert.ToInt32(reader["dueAmount"]);
                        DateTime bill_start_date = Convert.ToDateTime(reader["bill_start_date"]);
                        DateTime bill_end_date = Convert.ToDateTime(reader["bill_end_date"]);
                        DateTime bill_generated_date = Convert.ToDateTime(reader["bill_generated_date"]);
                        DateTime due_date = Convert.ToDateTime(reader["due_date"]);
                        int customer_id = Convert.ToInt32(reader["customer_id"]);
                        string billing_state = reader["billing_state"].ToString();

                        // Display or process the data
                        Console.WriteLine($"{++i}: Billing ID = {billing_id}, Units = {billed_units}, Meter ID = {meter_id}, Price = {price:C}, Due Amount = {dueAmount:C},");
                        //Console.WriteLine($"    Start: {bill_start_date:d}, End: {bill_end_date:d}, Generated: {bill_generated_date:d}, Due: {due_date:d}");
                        //Console.WriteLine($"    Customer ID = {customer_id}, State = {billing_state}");
                        Console.WriteLine("----------------------------------------------------");
                    }
                    if (i == 0)
                    {
                        Console.WriteLine("no customer with that id");
                    }
                }
            }

        }

        public void displayPaidBilllingsWithCid(SqlConnection conn, int customerId)
        {
            string query = "SELECT * FROM Billing WHERE ( customer_id = " + customerId + "  and  billing_state='Paid'  )";

            using (SqlCommand cm = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cm.ExecuteReader())
                {


                    Console.WriteLine("--------billing of this month -------- :");
                    int i = 0;
                    while (reader.Read())
                    {
                        // Read each column from the data reader
                        int billing_id = Convert.ToInt32(reader["billing_id"]);
                        int billed_units = Convert.ToInt32(reader["billed_units"]);
                        int meter_id = Convert.ToInt32(reader["meter_id"]);
                        decimal price = Convert.ToInt32(reader["price"]);
                        decimal dueAmount = Convert.ToInt32(reader["dueAmount"]);
                        DateTime bill_start_date = Convert.ToDateTime(reader["bill_start_date"]);
                        DateTime bill_end_date = Convert.ToDateTime(reader["bill_end_date"]);
                        DateTime bill_generated_date = Convert.ToDateTime(reader["bill_generated_date"]);
                        DateTime due_date = Convert.ToDateTime(reader["due_date"]);
                        int customer_id = Convert.ToInt32(reader["customer_id"]);
                        string billing_state = reader["billing_state"].ToString();

                        // Display or process the data
                        Console.WriteLine($"{++i}: Billing ID = {billing_id}, Units = {billed_units}, Meter ID = {meter_id}, Price = {price:C}, Due Amount = {dueAmount:C},");
                        //Console.WriteLine($"    Start: {bill_start_date:d}, End: {bill_end_date:d}, Generated: {bill_generated_date:d}, Due: {due_date:d}");
                        //Console.WriteLine($"    Customer ID = {customer_id}, State = {billing_state}");
                        Console.WriteLine("----------------------------------------------------");
                    }
                    if (i == 0)
                    {
                        Console.WriteLine("no customer with that id");
                    }
                }
            }
        }


        public  void InsertBilling(SqlConnection conn)
        {
            Console.WriteLine("----- Insert New Billing -----");
            Console.Write("Enter Billing ID: ");
            int billingId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Customer ID: ");
            int customerId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Meter ID: ");
            int meterId = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Billed Units: ");
            int billedUnits = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Price: ");
            int price = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Due Amount: ");
            int dueAmount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Bill Start Date (yyyy-MM-dd): ");
            DateTime startDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Bill End Date (yyyy-MM-dd): ");
            DateTime endDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Due Date (yyyy-MM-dd): ");
            DateTime dueDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Billing Status (Paid/Unpaid): ");
            string billingStatus = Console.ReadLine();

            string query = "INSERT INTO Billing (billing_id, customer_id, meter_id, billed_units, price, dueAmount, bill_start_date, bill_end_date, due_date, billing_state) " +
                           "VALUES (@bid, @cid, @mid, @units, @price, @due, @start, @end, @dueDate, @state)";

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@bid", billingId);
                cmd.Parameters.AddWithValue("@cid", customerId);
                cmd.Parameters.AddWithValue("@mid", meterId);
                cmd.Parameters.AddWithValue("@units", billedUnits);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@due", dueAmount);
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);
                cmd.Parameters.AddWithValue("@dueDate", dueDate);
                cmd.Parameters.AddWithValue("@state", billingStatus);

                int rows = cmd.ExecuteNonQuery();
                Console.WriteLine(rows > 0 ? "Billing inserted successfully!" : "Insertion failed.");
            }
        }


    }
}
