namespace OnlineShop.DAL.ViewModels
{
    public class ReportViewModel
    {
        public List<SalesReport> SalesByYearAndMonth { get; set; }
        public List<SalesReport> SalesByProducts { get; set; }
        public List<SalesReport> SalesByProductCategories { get; set; }
        public List<SalesReport> SalesByCustomersAndYears { get; set; }
        public List<SalesReport> SalesByCity { get; set; }
        public List<SalesReport> Top10CustomersBySalesAmount { get; set; }
        public List<SalesReport> Top10CustomersBySalesAmountPerYear { get; set; }
        public List<SalesReport> Top10ProductsBySalesAmount { get; set; }
        public List<SalesReport> Top10ProductsBySalesProfit { get; set; }
        public List<SalesReport> Top10ProductsBySalesAmountPerYear { get; set; }
        
    }

}
