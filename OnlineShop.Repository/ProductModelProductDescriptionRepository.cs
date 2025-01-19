using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class ProductModelProductDescriptionRepository : BaseRepository<ProductModelProductDescription>, IProductModelProductDescriptionRepository
    {
        public ProductModelProductDescriptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
