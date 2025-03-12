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
    public class AddressRepository : IAddressRepository
    {
        private ResumSampleContext context;

        public AddressRepository(ResumSampleContext _context)
        {
            context=_context;
        }

        public void Add(Address address)
        {
            context.Addresses.Add(address);
        }

        public void Delete(int id)
        {
            context.Addresses.Remove(GetByID(id));
        }

        public void Delete(Address address)
        {
              context.Addresses.Remove(address);
        }

        public List<Address> GetAll()
        {
            return context.Addresses.ToList();
        }

        public Address GetByID(int id)
        {
           return context.Addresses.Find(id);
        }

        public bool IsExist(int id)
        {
            return context.Addresses.Any(p => p.Id == id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Address address)
        {
            context.Addresses.Update(address);
        }
    }
}
