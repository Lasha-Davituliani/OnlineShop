using OnlineShop.DAL.Entities;

namespace OnlineShop.BLL.Interfaces.ServicesInterfaces
{
    public interface IUserService
    {
        Task ChangeStatusAsync(string email, bool status);
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task<bool> LoginAsync(string email, string password);
        Task RegisterAsync(User user);
        Task ResetPasswordAsync(string email, string oldPassword, string newPassword);
    }
}
