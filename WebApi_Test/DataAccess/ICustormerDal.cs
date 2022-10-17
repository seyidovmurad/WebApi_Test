using WebApi_Test.Entities;
using WebApi_Test.Models;

namespace WebApi_Test.DataAccess
{
    public interface ICustomerDal: IEntityRepository<Customer>
    {
        List<CustomerOrderModel> GetCustomerOrdersById(string customerId);

        List<Customer> GetCustomerOrderBy(bool orderByDesc);
    }
}
