using CSharp_Assignment.Service;
using System;
using System.Linq;

namespace ECommerceApp
{
    class ECommerce 
    {

        public Customer Login()
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
