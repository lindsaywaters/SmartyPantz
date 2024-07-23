using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using SmartyPantz.Server.Models.Contracts;

namespace SmartyPantz.Server.Models.DataRepository
{
    public class UserRepository(ApplicationContext context) : IUserRepository
    {
        ApplicationContext _userContext = context;

       

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            return await _userContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            return await _userContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            _userContext.Users.Add(user);
            await _userContext.SaveChangesAsync();
        }

        public async Task<bool> UserExistsAsync(string username, string email)
        {
            return await _userContext.Users.AnyAsync(u => u.Username == username || u.Email == email);
        }
    }
}



