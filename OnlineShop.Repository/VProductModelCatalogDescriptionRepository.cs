using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class VProductModelCatalogDescriptionRepository : BaseRepository<VProductModelCatalogDescription>, IVProductModelCatalogDescriptionRepository
    {
        public VProductModelCatalogDescriptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
