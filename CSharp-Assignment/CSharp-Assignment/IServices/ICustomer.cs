using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp_Assignment.IServices
{
    public interface ICustomer
    {
        public void CreateCustomer(int customerid, string password, string name, string email, string address);
    }
}
