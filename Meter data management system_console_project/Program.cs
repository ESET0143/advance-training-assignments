using Meter_data_management_system.Auth;
using Meter_data_management_system.Data.Entity;
using System;
using System.Data.SqlClient;

namespace Meter_data_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = DBConnection.GetConnection())
            {
                try
                {
                    Console.WriteLine("Opening Connection ...");
                    conn.Open();
                    Console.WriteLine("Connection successful!");

                    Console.WriteLine("\n========== Are you a Customer or Admin? ==========");
                    Console.WriteLine("1. Customer");
                    Console.WriteLine("2. Admin");
                    Console.Write("Enter your role number: ");
                    int role = Convert.ToInt32(Console.ReadLine());

                    switch (role)
                    {
                        // ================== CUSTOMER SECTION ==================
                        case 1:
                            HandleCustomer(conn);
                            break;

                        // ================== ADMIN SECTION ==================
                        case 2:
                            HandleAdmin(conn);
                            break;

                        default:
                            Console.WriteLine("Invalid role number. Please restart the program.");
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
                finally
                {
                    conn.Close();
                    Console.WriteLine("Connection closed.");
                }
            }
        }

        // ------------------ CUSTOMER SECTION ------------------
        static void HandleCustomer(SqlConnection conn)
        {
            Console.WriteLine("\n========== Are you a New or Existing Customer? ==========");
            Console.WriteLine("1. New Customer");
            Console.WriteLine("2. Existing Customer");
            Console.Write("Enter your choice: ");
            int customerState = Convert.ToInt32(Console.ReadLine());
            RegisterPage register = new RegisterPage();
            switch (customerState)
            {
                case 1:
                    
                    register.NewRegistration(conn);
                    //when new customer enters what details/triggers we have to make
                    //we have to generate adresss id in sqeuence,
                    break;

                case 2:
                    bool exit = register.VerifyLogin(conn); 
                    while (!exit)
                    {
                        Console.WriteLine("\n========== CUSTOMER MENU ==========");
                        Console.WriteLine("1. Fetch All Billings by Customer ID");
                        Console.WriteLine("2. Fetch Upcoming Bills by Customer ID");
                        Console.WriteLine("3. Fetch All Paid Billings by Customer ID");
                        Console.WriteLine("4. Display All Service Centres");
                        Console.WriteLine("5. Display Full Profile");
                        Console.WriteLine("10. Exit");
                        Console.Write("Enter your choice: ");
                        string choice = Console.ReadLine();
                        Billing billing = new Billing();
                        Customer customer = new Customer();
                        Service_Centers serviceCenters = new Service_Centers();
                        switch (choice)
                        {
                            case "1":
                                Console.Write("Enter Customer ID: ");
                                int cid1 = Convert.ToInt32(Console.ReadLine());
                                billing.displayBilllingsWithCid(conn, cid1);
                                break;

                            case "2":
                                Console.Write("Enter Customer ID: ");
                                int cid2 = Convert.ToInt32(Console.ReadLine());
                                billing.displayUpCommingBilllingsWithCid(conn, cid2);
                                break;

                            case "3":
                                Console.Write("Enter Customer ID: ");
                                int cid3 = Convert.ToInt32(Console.ReadLine());
                                billing.displayPaidBilllingsWithCid(conn, cid3);
                                break;

                            case "4":
                                serviceCenters.Display_service_centres();
                                break;

                            case "5":
                                Console.Write("Enter Customer ID: ");
                                int cid4 = Convert.ToInt32(Console.ReadLine());
                                customer.DisplayMyFullProfile(conn, cid4);
                                break;

                            case "10":
                                exit = true;
                                Console.WriteLine("Exiting customer menu...");
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Please enter a valid option.");
                                break;
                        }
                    }
                    break;

                default:
                    Console.WriteLine("Invalid choice. Returning to main menu...");
                    break;
            }
        }

        // ------------------ ADMIN SECTION ------------------
        static void HandleAdmin(SqlConnection conn)
        {
            bool adminExit = false;

            while (!adminExit)
            {
                Console.WriteLine("\n========== ADMIN MENU ==========");
                Console.WriteLine("1. Insert New Address");
                Console.WriteLine("2. Insert New Customer");
                Console.WriteLine("3. Insert New Service Centre");
                Console.WriteLine("4. Display All Service Centres");
                Console.WriteLine("5. Insert New Meter");
                Console.WriteLine("10. Exit Admin Menu");
                Console.Write("Enter your choice: ");

                string adminChoice = Console.ReadLine();

                Customer c1 = new Customer();
                Service_Centers s1 = new Service_Centers();
                meters m1 = new meters();

                switch (adminChoice)
                {
                    case "1":
                        Adress a1 = new Adress();
                        a1.Insertadress(conn);
                        break;

                    case "2":
                        c1.InsertCustomer(conn);
                        break;

                    case "3":
                        s1.InsertServiceCentre(conn);
                        break;

                    case "4":
                        s1.Display_service_centres();
                        break;

                    case "5":
                        m1.InsertMeter(conn);
                        break;

                    case "10":
                        adminExit = true;
                        Console.WriteLine("Exiting admin menu...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a valid option.");
                        break;
                }
            }
        }
    }
}
