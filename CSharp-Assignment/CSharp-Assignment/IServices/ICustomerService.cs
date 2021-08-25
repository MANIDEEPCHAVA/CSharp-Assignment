using ECommerceApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Assignment.IServices
{
    public interface ICustomerService
    {
        public void AddCustomer(int customerid, string password, string name, string email, string address);
        public Customer FindCustomer(string email);
    }
}
