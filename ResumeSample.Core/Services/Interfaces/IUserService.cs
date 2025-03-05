using ResumeSample.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSample.Core.Services.Interfaces
{
    public interface IUserService
    {
        User GetUserByID(int id);
        List<User> GetAllUsers();
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        void DeleteUser(User user);
        void SaveUser();
    }
}
