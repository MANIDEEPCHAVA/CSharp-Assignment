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
            var cu = FindCustomer(email);
            if (cu != null)
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
                var userInput = new Customer();
                Console.Clear();
                Console.Write("Email: ");
                userInput.Email = Console.ReadLine();

                Console.Write("Password: ");
                userInput.Password = ReadPassword();

                var validCustomer = CustomerService.validCustomers
                .Where(c => c.Email.Equals(userInput.Email))
                .Where(c => c.Password.Equals(userInput.Password))
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
