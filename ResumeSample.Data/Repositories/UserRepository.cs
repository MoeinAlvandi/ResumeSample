using ResumeSample.Data.Context;
using ResumeSample.Domain.Interfaces;
using ResumeSample.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSample.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ResumSampleContext context;

        public UserRepository(ResumSampleContext _context)
        {
            context=_context;
        }

        public void Add(User user)
        {
            context.Users.Add(user);
        }

        public void Delete(int id)
        {
           context.Users.Remove(GetByID(id));
        }

        public void Delete(User user)
        {
           context.Users.Remove(user);
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public User GetByID(int id)
        {
            return context.Users.Find(id);
        }

        public bool IsExist(int id)
        {
           return context.Users.Any(p=>p.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(User user)
        {
            context.Users.Update(user);
        }
    }
}
