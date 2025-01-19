using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class BuildVersionRepository : BaseRepository<BuildVersion>, IBuildVersionRepository
    {
        public BuildVersionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
