using System;

namespace ECommerceApp
{
    public class Order
    {
        public int OrderNo { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal TotalAmount { get; set; }

        public Order CreateOrder(int orderno,int customerid,int productid,int quantity,decimal amount)
        {
            Order order = new Order()
            {
                OrderNo = orderno,
                CustomerId = customerid,
                ProductId = productid,
                Quantity = quantity,
                TotalAmount = quantity * amount,
            };
            return order;
        }
    }
}