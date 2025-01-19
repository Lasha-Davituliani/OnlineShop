using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class VGetAllCategoryRepository : BaseRepository<VGetAllCategory>, IVGetAllCategoryRepository
    {
        public VGetAllCategoryRepository(AppDbContext context) : base(context)
        {
        }
    }
}
