namespace OnlineShop.DAL.ViewModels
{
    public class OrderViewModel
    {
        public int SalesOrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string SalesOrderNumber { get; set; }
        public string? ShipMethod { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal Freight { get; set; }
        public decimal TotalDue { get; set; }
        public byte Status { get; set; }

        private IEnumerable<OrderDetailViewModel>? _orderDetails;
        public IEnumerable<OrderDetailViewModel> OrderDetails
        {
            get => _orderDetails ??= LoadOrderDetails();
            set => _orderDetails = value;
        }
        private IEnumerable<OrderDetailViewModel> LoadOrderDetails()
        {            
            return new List<OrderDetailViewModel>();
        }
    }
}
