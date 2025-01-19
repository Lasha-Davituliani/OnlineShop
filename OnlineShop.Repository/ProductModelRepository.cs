using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class ProductModelRepository : BaseRepository<ProductModel>, IProductModelRepository
    {
        public ProductModelRepository(AppDbContext context) : base(context)
        {
        }
    }
}
