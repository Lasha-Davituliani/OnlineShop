using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.BLL.Services
{
    public class ProductCategoryService : BaseLookupService<ProductCategoryViewModel>, IProductCategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductCategoryService(IUnitOfWork unitOfWork) : base((IBaseRepository<ProductCategoryViewModel>)unitOfWork.ProductCategoryRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
