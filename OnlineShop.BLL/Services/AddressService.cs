using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.BLL.Services
{
    public class AddressService : BaseLookupService<AddressViewModel>, IAddressService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddressService(IUnitOfWork unitOfWork) : base((IBaseRepository<AddressViewModel>)unitOfWork.AddressRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }
    }
}
