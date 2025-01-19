using AutoMapper;
using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.BLL.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper;
        }
        public async Task CreateAsync(OrderViewModel entity)
        {
            var order = _mapper.Map<SalesOrderHeader>(entity);
            await _unitOfWork.OrderRepository.AddAsync(order);
            await _unitOfWork.OrderRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(OrderViewModel entity)
        {
            var order = _mapper.Map<SalesOrderHeader>(entity);
            await _unitOfWork.OrderRepository.DeleteAsync(order);
        }

        public async Task<IEnumerable<OrderViewModel>> GetAllAsync()
        {
            var orders = await _unitOfWork.OrderRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<OrderViewModel>>(orders);
        }

        public async Task<OrderViewModel> GetByIdAsync(int id)
        {
            var order = await _unitOfWork.OrderRepository.GetByIdAsync(id);
            return _mapper.Map<OrderViewModel>(order);
        }

        public Task UpdateAsync(OrderViewModel entity)
        {
           var order = _mapper.Map<SalesOrderHeader>(entity);
            return _unitOfWork.OrderRepository.UpdateAsync(order);
        }
    }

}
