namespace SmartyPantz.Server.Models.Contracts
{
    public interface IUserProfileRepository
    {
        UserProfile GetUserProfile(int id);
        void UpdateUserProfile(UserProfile userProfile);
        void DeleteUserProfile(int userId);
    }
}
