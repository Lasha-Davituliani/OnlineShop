namespace OnlineShop.DAL.ViewModels
{
    public class ProductCategoryViewModel
    {
        public int ProductCategoryId { get; set; }
        public string Name { get; set; } = null!;
        public int ProductsCount { get; set; } // For List view
        public int? ParentProductCategoryId { get; set; } // For dropdown in Edit/Create
        public string? ParentCategoryName { get; set; } // Display parent category name
    }

}
