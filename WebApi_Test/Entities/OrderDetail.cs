using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi_Test.Entities
{
    [Table("Order Details")]
    public class OrderDetail: IEntity
    {
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal UnitPrice { get; set; }

        public short Quantity { get; set; }
    }
}
