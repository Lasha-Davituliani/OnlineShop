using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    public sealed class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }
    }
}
