using ResumeSample.Core.Services.Interfaces;
using ResumeSample.Domain.Interfaces;
using ResumeSample.Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResumeSample.Core.Services.Implementetions
{
    public class AddressService : IAddressService
    {
        private IAddressRepository addressRepository;

        public AddressService(IAddressRepository _addressRepository)
        {
            addressRepository=_addressRepository;
        }

        public void Add(Address address)
        {
           addressRepository.Add(address);
        }

        public void Delete(int id)
        {
           addressRepository.Delete(id);
        }

        public void Delete(Address address)
        {
            addressRepository.Delete(address);
        }

        public List<Address> GetAll()
        {
              return addressRepository.GetAll();
        }

        public Address GetByID(int id)
        {
            return addressRepository.GetByID(id);
        }

        public bool IsExist(int id)
        {
            return addressRepository.IsExist(id);
        }

        public void Save()
        {
            addressRepository.Save();
        }

        public void Update(Address address)
        {
            addressRepository.Update(address);
        }
    }
}
