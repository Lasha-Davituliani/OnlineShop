using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class VProductAndDescriptionRepository : BaseRepository<VProductAndDescription>, IVProductAndDescriptionRepository
    {
        public VProductAndDescriptionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
