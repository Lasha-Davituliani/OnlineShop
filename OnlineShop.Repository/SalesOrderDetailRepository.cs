using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class SalesOrderDetailRepository : BaseRepository<SalesOrderDetail>, ISalesOrderDetailRepository
    {
        public SalesOrderDetailRepository(AppDbContext context) : base(context)
        {
        }
    }
}
