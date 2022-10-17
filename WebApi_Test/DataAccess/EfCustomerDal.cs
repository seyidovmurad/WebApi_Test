using WebApi_Test.Entities;
using WebApi_Test.Models;

namespace WebApi_Test.DataAccess
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NortwindDbContext>, ICustomerDal
    {
        public List<Customer> GetCustomerOrderBy(bool orderByDesc)
        {
            using(var context = new NortwindDbContext())
            {
                var result = orderByDesc ?
                    context.Customers.OrderByDescending(c => c.ContactName).ToList() : 
                    context.Customers.OrderBy(c => c.ContactName).ToList();

                return result;
            }
        }

        public List<CustomerOrderModel> GetCustomerOrdersById(string customerId)
        {
            using(var context = new NortwindDbContext())
            {
                var result = from od in context.OrderDetails
                             join o in context.Orders
                             on od.OrderId equals o.OrderId
                             join p in context.Products
                             on od.ProductId equals p.ProductId
                             where o.CustomerId == customerId
                             select new CustomerOrderModel
                             {
                                 OrderId = o.OrderId,
                                 UnitPrice = od.UnitPrice,
                                 Quantity = od.Quantity,
                                 OrderDate = o.OrderDate,
                                 ShippedDate = o.ShippedDate,
                                 ShipAddress = o.ShipAddress,
                                 ShipCountry = o.ShipCountry,
                                 ShipName = o.ShipName,
                                 ProductName = p.ProductName,
                                 CustomerId = o.CustomerId,
                                 ProductId = p.ProductId
                             };
                return result.ToList();
            }
        }
    }
}
