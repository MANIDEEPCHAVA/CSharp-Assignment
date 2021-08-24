using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerceApp.IServices
{
    public interface IEcommerce
    {
        Customer Login();
        void CreateCustomer(int customerid, string password, string name, string email, string address);
        void AddShoppingCart(Customer valid_Customer);
        void ViewShoppingCart(Customer valid_Customer);
    }
}
