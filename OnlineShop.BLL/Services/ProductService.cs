using AutoMapper;
using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;        
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;            
        }

        public async Task<IEnumerable<ProductViewModel>> GetAllAsync()
        {
            var products = await _unitOfWork.ProductRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductViewModel>>(products); 
        }

        public async Task<ProductViewModel> GetByIdAsync(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
            return _mapper.Map<ProductViewModel>(product); 
        }

        public async Task CreateAsync(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model); 
            await _unitOfWork.ProductRepository.AddAsync(product);
            await _unitOfWork.ProductRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model); 
            await _unitOfWork.ProductRepository.UpdateAsync(product);
        }

        public async Task DeleteAsync(ProductViewModel model)
        {
            var product = _mapper.Map<Product>(model); 
            await _unitOfWork.ProductRepository.DeleteAsync(product);
        }
       
        async Task<List<ProductModelViewModel>> IProductService.GetModelsAsync()
        {
            var models = await _unitOfWork.ProductModelRepository.GetAllAsync();
            return (List<ProductModelViewModel>)_mapper.Map<IEnumerable<ProductModelViewModel>>(models);
        }

        async Task<List<ProductCategoryViewModel>> IProductService.GetCategoriesAsync()
        {
            var categories = await _unitOfWork.ProductCategoryRepository.GetAllAsync();
            return (List<ProductCategoryViewModel>)_mapper.Map<IEnumerable<ProductCategoryViewModel>>(categories);
        }
        
    }

}
