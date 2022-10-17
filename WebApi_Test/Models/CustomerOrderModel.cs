namespace WebApi_Test.Models
{
    public class CustomerOrderModel
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public string CustomerId { get; set; }

        public string ShipName { get; set; }

        public string ProductName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCountry { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippedDate { get; set; }

    }
}
