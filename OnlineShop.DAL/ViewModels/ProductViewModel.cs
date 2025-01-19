using OnlineShop.DAL.Entities;

namespace OnlineShop.DAL.ViewModels
{
    public class ProductViewModel
    {        
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public string ProductNumber { get; set; } = null!;
        public string? Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string? Size { get; set; }
        public int? ProductCategoryId { get; set; }         
        public int? ProductModelId { get; set; }        
        public int NumberOfOrders { get; set; }        
        public DateTime ModifiedDate { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }       
        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual ProductModel? ProductModel { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; } = new List<SalesOrderDetail>();
        public List<ProductCategoryViewModel> Categories { get; set; } = new List<ProductCategoryViewModel>();
        public List<ProductModelViewModel> Models { get; set; } = new List<ProductModelViewModel>();
    }

}
