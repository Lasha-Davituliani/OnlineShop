using OnlineShop.DAL.ViewModels;

namespace OnlineShop.BLL.Interfaces.ServicesInterfaces
{
    public interface IReportService
    {
        Task<IEnumerable<SalesReport>> GetSalesByYearAndMonthAsync();
        Task<IEnumerable<SalesReport>> GetSalesByProductsAsync();
        Task<IEnumerable<SalesReport>> GetSalesByProductCategoriesAsync();
        Task<IEnumerable<SalesReport>> GetSalesByCustomerAndYearAsync();
        Task<IEnumerable<SalesReport>> GetSalesByCityAsync();
        Task<IEnumerable<SalesReport>> GetTopCustomersBySalesAsync();
        Task<IEnumerable<SalesReport>> GetTopCustomersBySalesForEachYearAsync();
        Task<IEnumerable<SalesReport>> GetTopProductsBySalesAsync();
        Task<IEnumerable<SalesReport>> GetTopProductsByProfitAsync();
        Task<IEnumerable<SalesReport>> GetTopProductsBySalesForEachYearAsync();
    }
}
