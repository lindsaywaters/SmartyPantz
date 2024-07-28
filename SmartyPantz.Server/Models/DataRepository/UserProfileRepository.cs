using SmartyPantz.Server.Models.Contracts;

namespace SmartyPantz.Server.Models.DataRepository
{
    public class UserProfileRepository (ApplicationContext context) : IUserProfileRepository
    {
        ApplicationContext _userProfileContext = context;

        public UserProfile GetUserProfile(int userId)
        {
            return _userProfileContext.UserProfiles.Find(userId);
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            _userProfileContext.UserProfiles.Update(userProfile);
            _userProfileContext.SaveChanges();
        }

        public void DeleteUserProfile(int userId) 
        {
            var userProfile = _userProfileContext.UserProfiles.Find(userId);
                if (userProfile != null) 
            { 
                _userProfileContext.UserProfiles.Remove(userProfile);
                _userProfileContext.SaveChanges();
            }
        }
    }
}
