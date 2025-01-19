using Microsoft.EntityFrameworkCore.Storage;
using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.DAL.ApplicationDbContext;

namespace OnlineShop.Repository
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private AppDbContext _context;
        private IDbContextTransaction? _transaction;
        private bool _isDisposed = false;

        private readonly Lazy<IAddressRepository> _addressRepository;
        private readonly Lazy<IBuildVersionRepository> _buildVersionRepository;
        private readonly Lazy<ICustomerAddressRepository> _customerAddressRepository;
        private readonly Lazy<ICustomerRepository> _customerRepository;
        private readonly Lazy<IErrorLogRepository> _errorLogRepository;
        private readonly Lazy<IProducDescriptionRepository> _producDescriptionRepository;
        private readonly Lazy<IProductCategoryRepository> _productCategoryRepository;
        private readonly Lazy<IProductModelProductDescriptionRepository> _productModelProductDescriptionRepository;
        private readonly Lazy<IProductModelRepository> _productModelRepository;
        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ISalesOrderDetailRepository> _salesOrderDetailRepository;
        private readonly Lazy<IOrderRepository> _orderRepository;
        private readonly Lazy<IVGetAllCategoryRepository> _vGetAllCategoryRepository;
        private readonly Lazy<IVProductAndDescriptionRepository> _vProductAndDescriptionRepository;
        private readonly Lazy<IVProductModelCatalogDescriptionRepository> _vProductModelCatalogDescriptionRepository;
        private readonly Lazy<IUserRepository> _userRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _addressRepository = new Lazy<IAddressRepository>(() => new AddressRepository(_context));
            _buildVersionRepository = new Lazy<IBuildVersionRepository>(() => new BuildVersionRepository(_context));
            _customerAddressRepository = new Lazy<ICustomerAddressRepository>(() => new CustommerAddressRepository(_context));
            _customerRepository = new Lazy<ICustomerRepository>(() => new CustomerRepository(_context));
            _errorLogRepository = new Lazy<IErrorLogRepository>(() => new ErrorLogRepository(_context));
            _producDescriptionRepository = new Lazy<IProducDescriptionRepository>(() => new ProductDescriptionRepository(_context));
            _productCategoryRepository = new Lazy<IProductCategoryRepository>(() => new ProductCategoryRepository(_context));
            _productModelProductDescriptionRepository = new Lazy<IProductModelProductDescriptionRepository>(() => new ProductModelProductDescriptionRepository(_context));
            _productModelRepository = new Lazy<IProductModelRepository>(() => new ProductModelRepository(_context));
            _productRepository = new Lazy<IProductRepository>(() => new ProductRepository(_context));
            _salesOrderDetailRepository = new Lazy<ISalesOrderDetailRepository>(() => new SalesOrderDetailRepository(_context));
            _orderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(_context));
            _vGetAllCategoryRepository = new Lazy<IVGetAllCategoryRepository>(() => new VGetAllCategoryRepository(_context));
            _vProductAndDescriptionRepository = new Lazy<IVProductAndDescriptionRepository>(() => new VProductAndDescriptionRepository(_context));
            _vProductModelCatalogDescriptionRepository = new Lazy<IVProductModelCatalogDescriptionRepository>(() => new VProductModelCatalogDescriptionRepository(_context));
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(context));
        }

        public IAddressRepository AddressRepository => _addressRepository.Value;

        public IBuildVersionRepository BuildVersionRepository => _buildVersionRepository.Value;

        public ICustomerAddressRepository CustomerAddressRepository => _customerAddressRepository.Value;

        public ICustomerRepository CustomerRepository => _customerRepository.Value;

        public IErrorLogRepository ErrorLogRepository => _errorLogRepository.Value;

        public IProducDescriptionRepository ProducDescriptionRepository => _producDescriptionRepository.Value;

        public IProductCategoryRepository ProductCategoryRepository => _productCategoryRepository.Value;

        public IProductModelProductDescriptionRepository ProductModelProductDescriptionRepository => _productModelProductDescriptionRepository.Value;

        public IProductModelRepository ProductModelRepository => _productModelRepository.Value;

        public IProductRepository ProductRepository => _productRepository.Value;

        public ISalesOrderDetailRepository SalesOrderDetailRepository => _salesOrderDetailRepository.Value;

        public IOrderRepository OrderRepository => _orderRepository.Value;

        public IVGetAllCategoryRepository VGetAllCategoryRepository => _vGetAllCategoryRepository.Value;

        public IVProductAndDescriptionRepository VProductAndDescriptionRepository => _vProductAndDescriptionRepository.Value;

        public IVProductModelCatalogDescriptionRepository VProductModelCatalogDescriptionRepository => _vProductModelCatalogDescriptionRepository.Value;

        public IUserRepository UserRepository => _userRepository.Value;
        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction is already started!");
            }
            _transaction = _context?.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction is not started!");
            }

            try
            {
                SaveChanges();
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }       

        public void RollBackTransaction()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Transaction is not started!");
            }

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }
        public int SaveChanges() => _context.SaveChanges();

        private void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                if (disposing)
                {
                    _context?.Dispose();
                    _transaction?.Dispose();
                }
                _context = null;
                _transaction = null;
            }

            _isDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
