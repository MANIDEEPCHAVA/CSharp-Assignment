using CSharp_Assignment.IServices;
using ECommerceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Assignment.Service
{
    public class CustomerService : ICustomerService
    {
        Customer Customer = new Customer();
        public static List<Customer> validCustomers = new List<Customer>();

        public void AddCustomer(int customerid, string password, string name, string email, string address)
        {
            var customeraccount = FindCustomer(email);
            if (customeraccount != null)
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                Customer customer = Customer.CreateCustomer(customerid, password, name, email, address);
                validCustomers.Add(customer);
                Console.WriteLine($"{customer.Name} was created with {customer.Email}");
            }
        }
        public Customer FindCustomer(string email)
        {
            return validCustomers.Where(x => x.Email == email).FirstOrDefault();
        }
        public static Customer Login()
        {
            while (true)
            {
                string email;
                string password;
                Console.Clear();
                Console.Write("Email: ");
                email = Console.ReadLine();

                Console.Write("Password: ");
                password = ReadPassword();

                var validCustomer = CustomerService.validCustomers
                .Where(c => c.Email.Equals(email))
                .Where(c => c.Password.Equals(password))
                .FirstOrDefault();

                if (validCustomer != null)
                {
                    return validCustomer;
                }
                Console.WriteLine("\nInvalid username or password.");
                Console.ReadKey();
            }
        }

        public static string ReadPassword()
        {
            string password = "";
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        return null;
                    case ConsoleKey.Enter:
                        return password;
                    case ConsoleKey.Backspace:
                        password = password.Substring(0, (password.Length - 1));
                        Console.Write("\b \b");
                        break;
                    default:
                        password += key.KeyChar;
                        Console.Write("*");
                        break;
                }
            }
        }
    }
}
