using ECommerceApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharp_Assignment.Service
{
    public static class ProductService
    {
        public static List<Order> shoppingCart = new List<Order>();

        public static List<Product> productList = new List<Product>() {
                new Product(){Id = 1 , ProductName = "Icecream",UnitPrice = 15.00M},
                new Product(){ Id = 2, ProductName = "Chocolate", UnitPrice = 2.00M},
                new Product(){ Id = 3, ProductName = "Dell Laptop 5500 8GBRam", UnitPrice = 3799.00M},
                new Product(){ Id = 4, ProductName = "Laptop Bag" , UnitPrice = 10.00M},
                new Product(){ Id = 5, ProductName = "Logitech Wireless Mouse", UnitPrice = 59.00M},
                new Product(){ Id = 6, ProductName = "Keyboard with Backlight", UnitPrice = 160.00M},
                new Product(){ Id = 7, ProductName = "Dell Wireless Keyboard and Mouse Combo ", UnitPrice = 90.00M}

        };
        public static void BrowseProducts()
        {
            foreach (var item in productList)
            {
                Console.WriteLine(item.Id + "->" + item.ProductName);
            }
        }

        public static void AddShoppingCart(Customer validcustomer)
        {
            Console.Write("Enter the product ID you want to buy: ");
            int productId = int.Parse(Console.ReadLine());

            var selectedProduct = productList.FirstOrDefault(p => p.Id == productId);

            if (selectedProduct == null)
            {
                Console.WriteLine("Product not found");
                return;
            }

            Console.Write("Enter quantity to buy: ");
            int quantity = int.Parse(Console.ReadLine());
            Order order = new Order();
            order = order.CreateOrder(1, validcustomer.CustomerId, productId, quantity, selectedProduct.UnitPrice);
            shoppingCart.Add(order);
            Console.WriteLine($"{selectedProduct.ProductName} added into shopping cart.");
        }
        public static void ViewShoppingCart(Customer validcustomer)
        {
            var shoppingCart2 = from s in shoppingCart
                                join p in productList on s.ProductId equals p.Id
                                select new { p.ProductName, p.UnitPrice, s.Quantity, s.TotalAmount };
            var totalOrderAmount = 0M;
            totalOrderAmount = shoppingCart.Sum(s => s.TotalAmount);

            if (shoppingCart2.ToList().Count == 0)
            {
                Console.WriteLine("Shopping cart is empty. Go to browse products.");
                return;
            }
            foreach (var item in shoppingCart2)
            {
                Console.WriteLine(item.ProductName + " =>" + "OrderQuantity" + " " + item.Quantity + "=>" + "TotalAmount" + " " + item.TotalAmount);
            }
            Console.WriteLine("Total Items in Shopping Cart: " + shoppingCart2.Count());

        }
    }
}
