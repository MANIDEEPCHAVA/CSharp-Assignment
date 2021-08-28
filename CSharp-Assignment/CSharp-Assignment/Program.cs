using CSharp_Assignment.Service;
using System;

namespace ECommerceApp
{
    class Program
    {
        static Customer ValidCustomer;
        static bool isLogged = false;
        static void Main(string[] args)
        {
            CustomerService customer = new CustomerService();
            bool end = false;
            while (!end)
            {
                Console.WriteLine("\nChoose the following options:");
                Options();
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter your name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter email");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        string password = Console.ReadLine();
                        Console.WriteLine("Enter Address");
                        string address = Console.ReadLine();
                        customer.AddCustomer(1, password, name, email, address);
                        break;

                    case 2:
                        ValidCustomer = Login();
                        break;

                    case 3:
                        BrowseProducts();
                        AddShoppingCart(ValidCustomer);
                        break;
                    case 4:
                        ViewShoppingCart(ValidCustomer);                        
                        break;
                    case 5:
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        break;
                }
            }
        }

        public static void Options()
        {
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. BrowseProducts");
            Console.WriteLine("4. View shopping cart");
            Console.WriteLine("5. Quit");
            Console.WriteLine();
        }


        public static Customer Login()
        {
            var valid_Customer = CustomerService.Login();
            isLogged = true;
            return valid_Customer;
        }

        public static void BrowseProducts()
        {
            if (isLogged)
            {
                Console.WriteLine($"Login as {ValidCustomer.Name}");
                ProductService.BrowseProducts();
            }
            else
            {
                Console.WriteLine("please Login ");
            }
        }
        public static void AddShoppingCart(Customer validcustomer)
        {
            if (isLogged)
            {
                ProductService.AddShoppingCart(validcustomer);
            }
        }
        public static void ViewShoppingCart(Customer validcustomer)
        {
            if(isLogged)
            {
                ProductService.ViewShoppingCart(validcustomer);
            }
            else
            {
                Console.WriteLine("Please Login");
            }
        }
    }
}

