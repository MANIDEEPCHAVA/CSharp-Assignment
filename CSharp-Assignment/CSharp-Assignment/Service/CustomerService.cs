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

        public static Customer FindCustomer(string email)
        {
            return validCustomers.Where(x => x.Email == email).FirstOrDefault();
        }

    }
}
