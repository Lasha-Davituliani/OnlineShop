using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.ViewModels;


namespace OnlineShop.BLL.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByYearAndMonthAsync()
        {
            return await _reportRepository.GetSalesByYearAndMonthAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByProductsAsync()
        {
            return await _reportRepository.GetSalesByProductsAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByProductCategoriesAsync()
        {
            return await _reportRepository.GetSalesByProductCategoriesAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByCustomerAndYearAsync()
        {
            return await _reportRepository.GetSalesByCustomerAndYearAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByCityAsync()
        {
            return await _reportRepository.GetSalesByCityAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopCustomersBySalesAsync()
        {
            return await _reportRepository.GetTopCustomersBySalesAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopCustomersBySalesForEachYearAsync()
        {
            return await _reportRepository.GetTopCustomersBySalesForEachYearAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopProductsBySalesAsync()
        {
            return await _reportRepository.GetTopProductsBySalesAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopProductsByProfitAsync()
        {
            return await _reportRepository.GetTopProductsByProfitAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopProductsBySalesForEachYearAsync()
        {
            return await _reportRepository.GetTopProductsBySalesForEachYearAsync();
        }
    }

}
