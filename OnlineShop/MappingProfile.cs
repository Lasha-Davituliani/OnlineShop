using AutoMapper;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<ProductCategory, ProductCategoryViewModel>().ReverseMap();            
            CreateMap<ProductModel, ProductModelViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<SalesOrderHeader, OrderViewModel>().ReverseMap();
            CreateMap<SalesOrderDetail, OrderDetailViewModel>().ReverseMap();
            CreateMap<SalesOrderHeader, OrderListViewModel>().ReverseMap();

        }
    }
}
