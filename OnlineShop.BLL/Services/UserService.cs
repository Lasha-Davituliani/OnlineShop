using OnlineShop.BLL.Interfaces.RepositoriesInterfaces;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.Entities;
using OnlineShop.Extensions;


namespace OnlineShop.BLL.Services
{
    public sealed class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _unitOfWork.UserRepository.GetByIdAsync(id);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return (User?)await _unitOfWork.UserRepository.GetAllAsync();
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            return await FindUserByEmailAndPasswordAsync(email, password, true) != null;
        }

        public async Task ResetPasswordAsync(string email, string oldPassword, string newPassword)
        {
            var user = await FindUserByEmailAndPasswordAsync(email, oldPassword) ?? throw new InvalidOperationException("You entered wrong email or password!");

            try
            {
                user.Password = newPassword.GetHashedString();
                _unitOfWork.BeginTransaction();
                _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.UserRepository.SaveChangesAsync();
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollBackTransaction();
                throw;
            }
        }

        public async Task ChangeStatusAsync(string email, bool status)
        {
            var user = await FindUserByEmailAsync(email);

            if (user == null)
            {
                throw new InvalidOperationException("No such user found!");
            }

            try
            {
                user.IsActive = status;
                _unitOfWork.BeginTransaction();
                _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.UserRepository.SaveChangesAsync();
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollBackTransaction();
                throw;
            }
        }

        public async Task RegisterAsync(User user)
        {
            user.Password = user.Password.GetHashedString();

            try
            {
                _unitOfWork.BeginTransaction();
                await _unitOfWork.UserRepository.AddAsync(user);
                await _unitOfWork.UserRepository.SaveChangesAsync();
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollBackTransaction();
                throw;
            }
        }

        private async Task<User?> FindUserByEmailAsync(string email)
        {
            ArgumentNullException.ThrowIfNull(email, nameof(email));

            return (User?)await _unitOfWork.UserRepository.GetAllAsync();
        }

        private async Task<User?> FindUserByEmailAndPasswordAsync(string email, string password, bool isLoginCalled = false)
        {
            ArgumentNullException.ThrowIfNull(email, nameof(email));
            ArgumentNullException.ThrowIfNull(password, nameof(password));

            var user = await FindUserByEmailAsync(email);
            if (user == null) return null;

            if (user!.BlockTime.HasValue && user.BlockTime > DateTime.UtcNow) return null;

            var hashedPassword = password.GetHashedString();

            if (user.Password != hashedPassword)
            {
                if (isLoginCalled)
                {
                    user.FailedLogginAttempts++;
                    if (user.FailedLogginAttempts >= 3)
                    {
                        user.BlockTime = DateTime.UtcNow.AddHours(1);
                    }
                }
                else
                {
                    user.FailedPasswordRessetAttempts++;
                    if (user.FailedPasswordRessetAttempts >= 3)
                    {
                        user.BlockTime = DateTime.UtcNow.AddHours(1);
                    }
                }

                _unitOfWork.UserRepository.UpdateAsync(user);
                await _unitOfWork.UserRepository.SaveChangesAsync();
                return null;
            }

            if (isLoginCalled)
            {
                user.FailedLogginAttempts = 0;
            }
            else
            {
                user.FailedPasswordRessetAttempts = 0;
            }

            return user.Password == hashedPassword ? user : null;
        }
    }
}
