using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.Controllers
{
    public class ReportController : Controller
    {
        private readonly IReportService _reportService;

        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        public async Task<IActionResult> Index()
        {
            var model = new ReportViewModel
            {
                SalesByYearAndMonth = (await _reportService.GetSalesByYearAndMonthAsync()).ToList(),
                SalesByProducts = (await _reportService.GetSalesByProductsAsync()).ToList(),
                SalesByProductCategories = (await _reportService.GetSalesByProductCategoriesAsync()).ToList(),
                SalesByCustomersAndYears = (await _reportService.GetSalesByCustomerAndYearAsync()).ToList(),
                SalesByCity = (await _reportService.GetSalesByCityAsync()).ToList(),
                Top10CustomersBySalesAmount = (await _reportService.GetTopCustomersBySalesAsync()).ToList(),
                Top10CustomersBySalesAmountPerYear = (await _reportService.GetTopCustomersBySalesForEachYearAsync()).ToList(),
                Top10ProductsBySalesAmount = (await _reportService.GetTopProductsBySalesAsync()).ToList(),
                Top10ProductsBySalesProfit = (await _reportService.GetTopProductsByProfitAsync()).ToList(),
                Top10ProductsBySalesAmountPerYear = (await _reportService.GetTopProductsBySalesForEachYearAsync()).ToList()
            };

            return View(model);
        }
        public async Task<IActionResult> SalesByYearAndMonth()
        {
            var model = new ReportViewModel
            {
                SalesByYearAndMonth = (await _reportService.GetSalesByYearAndMonthAsync()).ToList()
            };
            return View(model);
        }
        public async Task<IActionResult> SalesByProducts()
        {
            var model = new ReportViewModel
            {
                SalesByProducts = (await _reportService.GetSalesByProductsAsync()).ToList()
            };
            return View(model);
        }
        public async Task<IActionResult> SalesByProductCategories()
        {
            var model = new ReportViewModel
            {
                SalesByProductCategories = (await _reportService.GetSalesByProductCategoriesAsync()).ToList()
            };
            return View(model);
        }
        public async Task<IActionResult> SalesByCustomersAndYears()
        {
            var model = new ReportViewModel
            {
                SalesByCustomersAndYears = (await _reportService.GetSalesByCustomerAndYearAsync()).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> SalesByCity()
        {
            var model = new ReportViewModel
            {
                SalesByCity = (await _reportService.GetSalesByCityAsync()).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Top10CustomersBySalesAmount()
        {
            var model = new ReportViewModel
            {
                Top10CustomersBySalesAmount = (await _reportService.GetTopCustomersBySalesAsync()).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Top10CustomersBySalesAmountPerYear()
        {
            var model = new ReportViewModel
            {
                Top10CustomersBySalesAmountPerYear = (await _reportService.GetTopCustomersBySalesForEachYearAsync()).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Top10ProductsBySalesAmount()
        {
            var model = new ReportViewModel
            {
                Top10ProductsBySalesAmount = (await _reportService.GetTopProductsBySalesAsync()).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Top10ProductsBySalesProfit()
        {
            var model = new ReportViewModel
            {
                Top10ProductsBySalesProfit = (await _reportService.GetTopProductsByProfitAsync()).ToList()
            };
            return View(model);
        }

        public async Task<IActionResult> Top10ProductsBySalesAmountPerYear()
        {
            var model = new ReportViewModel
            {
                Top10ProductsBySalesAmountPerYear = (await _reportService.GetTopProductsBySalesForEachYearAsync()).ToList()
            };
            return View(model);
        }
    }
}
