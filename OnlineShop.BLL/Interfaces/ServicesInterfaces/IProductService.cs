using OnlineShop.DAL.ViewModels;

namespace OnlineShop.BLL.Interfaces.ServicesInterfaces
{
    public interface IProductService : IBaseLookupService<ProductViewModel>
    {
        Task<List<ProductCategoryViewModel>> GetCategoriesAsync();
        Task<List<ProductModelViewModel>> GetModelsAsync();        
    }
}
