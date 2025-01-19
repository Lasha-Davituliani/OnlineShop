using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.DAL.ViewModels
{
    public class OrderDetailViewModel
    {
        public int SalesOrderDetailId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public short OrderQty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal UnitPriceDiscount { get; set; }
        public decimal LineTotal { get; set; }
    }
}
