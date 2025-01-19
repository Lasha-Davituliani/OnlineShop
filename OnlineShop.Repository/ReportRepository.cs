using Microsoft.EntityFrameworkCore;
using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.Repository
{
    public class ReportRepository : IReportRepository
    {
        private readonly AppDbContext _context;

        public ReportRepository(AppDbContext context)
        {
            _context = context;
        }
       
        public async Task<IEnumerable<SalesReport>> GetSalesByYearAndMonthAsync()
        {
            return await _context.SalesOrderHeaders
                .GroupBy(o => new { o.OrderDate.Year, o.OrderDate.Month })
                .Select(g => new SalesReport
                {
                    Label = $"{g.Key.Year}-{g.Key.Month:D2}",
                    SalesAmount = g.Sum(o => o.TotalDue)
                })
                .ToListAsync();
        }
        public async Task<IEnumerable<SalesReport>> GetSalesByProductsAsync()
        {
            return await _context.SalesOrderDetails
                .GroupBy(od => od.Product.Name)
                .Select(g => new SalesReport
                {
                    Label = g.Key,
                    SalesAmount = g.Sum(od => od.LineTotal)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByProductCategoriesAsync()
        {
            return await _context.SalesOrderDetails
                .Include(od => od.Product)
                .ThenInclude(p => p.ProductCategory)
                .GroupBy(od => od.Product.ProductCategory.Name)
                .Select(g => new SalesReport
                {
                    Label = g.Key,
                    SalesAmount = g.Sum(od => od.LineTotal)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByCustomerAndYearAsync()
        {
            return await _context.SalesOrderHeaders
                .GroupBy(o => new { o.Customer.FirstName,o.Customer.LastName, o.OrderDate.Year })
                .Select(g => new SalesReport
                {
                    Label = $"{g.Key.FirstName} - {g.Key.LastName} - {g.Key.Year}",
                    SalesAmount = g.Sum(o => o.TotalDue)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetSalesByCityAsync()
        {
            return await _context.SalesOrderHeaders
                .Include(o => o.Customer)
                .ThenInclude(c => c.CustomerAddresses)
                .GroupBy(o => o.Customer.CustomerAddresses.FirstOrDefault().Address.City)
                .Select(g => new SalesReport
                {
                    Label = g.Key,
                    SalesAmount = g.Sum(o => o.TotalDue)
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopCustomersBySalesAsync()
        {
            return await _context.SalesOrderHeaders
                .Include(o => o.Customer)
                .GroupBy(o => new { o.Customer.FirstName, o.Customer.LastName })
                .Select(g => new SalesReport
                {
                    Label = $"{g.Key.FirstName} {g.Key.LastName}",
                    SalesAmount = g.Sum(o => o.TotalDue)
                })
                .OrderByDescending(r => r.SalesAmount)
                .Take(10)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopCustomersBySalesForEachYearAsync()
        {
            return await _context.SalesOrderHeaders .Include(o => o.Customer)
                .GroupBy(o => new { o.Customer.FirstName, o.Customer.LastName, o.OrderDate.Year })
                .Select(g => new SalesReport
                {
                    Label = $"{g.Key.FirstName}- {g.Key.LastName} - {g.Key.Year}",
                    SalesAmount = g.Sum(o => o.TotalDue)
                })
                .OrderByDescending(r => r.SalesAmount)
                .Take(10)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopProductsBySalesAsync()
        {
            return await _context.SalesOrderDetails
                .GroupBy(od => od.Product.Name)
                .Select(g => new SalesReport
                {
                    Label = g.Key,
                    SalesAmount = g.Sum(od => od.LineTotal)
                })
                .OrderByDescending(r => r.SalesAmount)
                .Take(10)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopProductsByProfitAsync()
        {
            return await _context.SalesOrderDetails
                .GroupBy(od => od.Product.Name)
                .Select(g => new SalesReport
                {
                    Label = g.Key,
                    SalesAmount = g.Sum(od => od.LineTotal),
                    SalesProfit = g.Sum(od => (od.LineTotal - (od.Product.StandardCost * od.OrderQty)))
                })
                .OrderByDescending(r => r.SalesProfit)
                .Take(10)
                .ToListAsync();
        }

        public async Task<IEnumerable<SalesReport>> GetTopProductsBySalesForEachYearAsync()
        {
            return await _context.SalesOrderDetails
                .GroupBy(od => new { od.Product.Name, od.SalesOrder.OrderDate.Year })
                .Select(g => new SalesReport
                {
                    Label = $"{g.Key.Name} - {g.Key.Year}",
                    SalesAmount = g.Sum(od => od.LineTotal)
                })
                .OrderByDescending(r => r.SalesAmount)
                .Take(10)
                .ToListAsync();
        }
    }
}
