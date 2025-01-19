﻿namespace OnlineShop.BLL.Interfaces.RepositoriesInterfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(params object?[]? keyValue);
        Task SaveChangesAsync();
    }
}
