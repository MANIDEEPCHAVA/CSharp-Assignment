using CSharp_Assignment.IServices;
using CSharp_Assignment.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp
{
    public class Customer : ICustomer
    {
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        public void CreateCustomer(int customerid, string password, string name, string email, string address)
        {
            var cu = CustomerService.FindCustomer(email);
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
                CustomerService.validCustomers.Add(customer);
                Console.WriteLine($"{customer.Name} was created with {customer.Email}");
            }
        }
    }
}