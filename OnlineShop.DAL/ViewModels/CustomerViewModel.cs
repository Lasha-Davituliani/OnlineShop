namespace OnlineShop.DAL.ViewModels
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? EmailAddress { get; set; }
        public string? Phone { get; set; }
        public string? CompanyName { get; set; }
        public string? SalesPerson { get; set; }
    }

}
