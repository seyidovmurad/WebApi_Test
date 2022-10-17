using WebApi_Test.Entities;

namespace WebApi_Test.DataAccess
{
    public class EfProductDal: EfEntityRepositoryBase<Product, NortwindDbContext>, IProductDal
    {
    }
}
