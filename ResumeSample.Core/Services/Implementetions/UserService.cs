using ResumeSample.Core.Services.Interfaces;
using ResumeSample.Domain.Interfaces;
using ResumeSample.Domain.Models.Auth;

namespace ResumeSample.Core.Services.Implementetions
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }


        public void AddUser(User user)
        {
            userRepository.Add(user);
            SaveUser();
        }

        public void DeleteUser(int id)
        {
            userRepository.Delete(id);
            SaveUser();
        }

        public void DeleteUser(User user)
        {
            userRepository.Delete(user);
            SaveUser();
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAll();
        }

        public User GetUserByID(int id)
        {
            return userRepository.GetByID(id);
        }

        public void SaveUser()
        {
            userRepository.Save();
        }

        public void UpdateUser(User user)
        {
            userRepository.Update(user);
            SaveUser();
        }
    }
}
