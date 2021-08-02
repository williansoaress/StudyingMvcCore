using StudyingMvcCore.Business.Models;
using System;
using System.Threading.Tasks;

namespace StudyingMvcCore.Business.Interfaces
{
    public interface ICustomerService : IDisposable
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
        Task Remove(Guid id);
        Task UpdateAddress(Address address);
    }
}
