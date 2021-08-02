using StudyingMvcCore.Business.Interfaces;
using StudyingMvcCore.Business.Models;
using System;
using System.Threading.Tasks;

namespace StudyingMvcCore.Business.Services
{
    public class CustomerService : BaseService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IAddressRepository _addressRepository;


        public CustomerService(ICustomerRepository customerRepository, 
                               IAddressRepository addressRepository)
        {
            _customerRepository = customerRepository;
            _addressRepository = addressRepository;
        }

        public async Task Add(Customer customer)
        {
            await _customerRepository.Add(customer);
        }

        public async Task Update(Customer customer)
        {
            await _customerRepository.Update(customer);
        }

        public async Task Remove(Guid id)
        {
            await _customerRepository.Remove(id);
        }


        public async Task UpdateAddress(Address address)
        {
            await _addressRepository.Update(address);
        }

        public void Dispose()
        {
            _customerRepository?.Dispose();
            _addressRepository?.Dispose();
        }
    }
}
