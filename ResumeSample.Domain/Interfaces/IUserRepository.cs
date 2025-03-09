using ResumeSample.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSample.Domain.Interfaces
{
    public interface IUserRepository
    {
        User GetByID(int id);//find
        List<User> GetAll();//select * 

        bool IsExist(int id);

        void Add(User user);//insert
        void Update(User user);//update
        void Delete(int id);//delete
        void Delete(User user);//delete
        void Save();//commit
    }
}
