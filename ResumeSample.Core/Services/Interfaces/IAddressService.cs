using ResumeSample.Core.Services.Implementetions;
using ResumeSample.Domain.Models.Auth;

namespace ResumeSample.Core.Services.Interfaces
{
   public interface IAddressService
    {
        Address GetByID(int id);//find
        List<Address> GetAll();//select * 

        bool IsExist(int id);

        void Add(Address address);//insert
        void Update(Address address);//update
        void Delete(int id);//delete
        void Delete(Address address);//delete
        void Save();//commit
    }
}
