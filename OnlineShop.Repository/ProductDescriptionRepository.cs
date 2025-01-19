using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class ProductDescriptionRepository : BaseRepository<ProductDescription>, IProducDescriptionRepository
    {
        public ProductDescriptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
