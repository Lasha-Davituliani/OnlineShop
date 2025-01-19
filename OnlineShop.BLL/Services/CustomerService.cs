using AutoMapper;
using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.Entities;
using OnlineShop.DAL.ViewModels;


public class CustomerService : ICustomerService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IBaseRepository<Customer> _customerRepository;
    private readonly IMapper _mapper;

    public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerViewModel>> GetAllAsync()
    {
        var customer = await _unitOfWork.CustomerRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<CustomerViewModel>>(customer); 
    }

    public async Task<CustomerViewModel> GetByIdAsync(int id)
    {
        var customer = await _unitOfWork.CustomerRepository.GetByIdAsync(id);
        return _mapper.Map<CustomerViewModel>(customer); 
    }

    public async Task CreateAsync(CustomerViewModel model)
    {
        var customer = _mapper.Map<Customer>(model); 
        await _unitOfWork.CustomerRepository.AddAsync(customer);
        await _unitOfWork.CustomerRepository.SaveChangesAsync();
    }
    public async Task UpdateAsync(CustomerViewModel model)
    {
        var customer = _mapper.Map<Customer>(model); 
        await _unitOfWork.CustomerRepository.UpdateAsync(customer);
    }
    public async Task DeleteAsync(CustomerViewModel model)
    {
        var customer = _mapper.Map<Customer>(model);
        await _unitOfWork.CustomerRepository.DeleteAsync(customer);
    }
}
