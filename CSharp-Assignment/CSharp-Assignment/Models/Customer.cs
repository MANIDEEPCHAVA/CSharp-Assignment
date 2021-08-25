using CSharp_Assignment.IServices;
using CSharp_Assignment.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ECommerceApp
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        private string Address { get; set; }


        public Customer CreateCustomer(int customerid, string password, string name, string email, string address)
        {
            Customer customer = new Customer
                {
                    CustomerId = customerid,
                    Password = password,
                    Name = name,
                    Email = email,
                    Address = address
                };
            return customer;
            }
        }
        
    }
