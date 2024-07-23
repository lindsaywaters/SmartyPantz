using System.Threading.Tasks;
namespace SmartyPantz.Server.Models.Contracts

{
    public interface IUserRepository
    
            
      {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<User?> GetUserByEmailAsync(string email);
        Task AddUserAsync(User user);
        Task<bool> UserExistsAsync(string username, string email);
    }
}

