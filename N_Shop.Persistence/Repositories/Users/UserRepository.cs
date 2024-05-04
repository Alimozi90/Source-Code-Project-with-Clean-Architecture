using Microsoft.EntityFrameworkCore;
using N_Shop.Application.Contracts.Persistence.Users;
using N_Shop.Domain.Users;
using N_Shop.Persistence.Repositories.Common;

namespace N_Shop.Persistence.Repositories.Users
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly N_ShopDbContext _context;
        public UserRepository(N_ShopDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> ExistUserName(string userName)
        {
            return await _context.Users.AnyAsync(u => u.UserName == userName);
        }

        public async Task<bool> ExistEmail(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task<User> GetUserByUserNamePassword(string userName, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == userName && u.Password == password);
            if (user != null)
                await _context.Entry(user).Reference(u => u.Role).LoadAsync();
            return user;
        }
    }
}
