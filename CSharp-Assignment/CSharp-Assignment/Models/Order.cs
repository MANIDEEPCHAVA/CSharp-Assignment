using System;

namespace ECommerceApp
{
    public class Order
    {
        public string No { get; set; }
        public int Customer_Id { get; set; }
        public int ProductId { get; set; }
        public int OrderQuantity { get; set; }
        public decimal TotalAmount { get; set; }
    }
}