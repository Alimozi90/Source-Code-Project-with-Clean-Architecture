using N_Shop.Application.Contracts.Persistence.Common;
using N_Shop.Domain.Users;

namespace N_Shop.Application.Contracts.Persistence.Users
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> ExistUserName(string userName);
        Task<bool> ExistEmail(string email);
        Task<User> GetUserByUserNamePassword(string userName, string password);
    }
}
