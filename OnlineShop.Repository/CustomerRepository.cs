using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.Repositories;

namespace OnlineShop.Repository
{
    internal sealed class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(AppDbContext context) : base(context)
        {
        }
    }    
}
