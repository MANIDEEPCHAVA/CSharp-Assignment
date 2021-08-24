using ECommerceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Assignment.Service
{
    public static class CustomerService
    {
        public static List<Customer> validCustomers = new List<Customer>();

        public static void CreateCustomer(int customerid, string password, string name, string email, string address)
        {
            var cu = FindCustomer(email);
            if (cu != null)
            {
                Console.WriteLine("Account already exists");
            }
            else
            {
                Customer customer = new Customer
                {
                    CustomerId = customerid,
                    Password = password,
                    Name = name,
                    Email = email,
                    Address = address
                };
                validCustomers.Add(customer);
                Console.WriteLine($"{customer.Name} was created with {customer.Email}");
            }
        }

        private static Customer FindCustomer(string email)
        {
            return validCustomers.Where(x => x.Email == email).FirstOrDefault();
        }

    }
}
