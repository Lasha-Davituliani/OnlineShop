namespace OnlineShop.BLL.Interfaces.RepositoriesInterfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IAddressRepository AddressRepository { get; }
        IBuildVersionRepository BuildVersionRepository { get; }
        ICustomerAddressRepository CustomerAddressRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IErrorLogRepository ErrorLogRepository { get; }
        IProducDescriptionRepository ProducDescriptionRepository { get; }
        IProductCategoryRepository ProductCategoryRepository { get; }
        IProductModelProductDescriptionRepository ProductModelProductDescriptionRepository { get; }
        IProductModelRepository ProductModelRepository { get; }
        IProductRepository ProductRepository { get; }
        ISalesOrderDetailRepository SalesOrderDetailRepository { get; }
        IOrderRepository OrderRepository { get; }
        IVGetAllCategoryRepository VGetAllCategoryRepository { get; }
        IVProductAndDescriptionRepository VProductAndDescriptionRepository { get; }
        IVProductModelCatalogDescriptionRepository VProductModelCatalogDescriptionRepository { get; }
        IUserRepository UserRepository { get; }

        void BeginTransaction();
        void CommitTransaction();       
        void RollBackTransaction();
        int SaveChanges();
    }
}
