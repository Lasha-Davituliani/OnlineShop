using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;

namespace OnlineShop.BLL.Services
{
    public class BaseLookupService<T> : IBaseLookupService<T> where T : class
    {

        private readonly IBaseRepository<T>? _repository;

        protected BaseLookupService(IBaseRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }        

        public async Task CreateAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            await _repository!.AddAsync(entity);
            await _repository.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity, nameof(entity));

            await _repository!.DeleteAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository!.GetAllAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _repository!.GetByIdAsync(id);
        }       

        public async Task UpdateAsync(T entity)
        {
            await _repository!.UpdateAsync(entity);
        }
    }
}
