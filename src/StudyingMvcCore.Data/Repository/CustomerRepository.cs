using Microsoft.EntityFrameworkCore;
using StudyingMvcCore.Business.Interfaces;
using StudyingMvcCore.Business.Models;
using StudyingMvcCore.Data.Context;
using System;
using System.Threading.Tasks;

namespace StudyingMvcCore.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(StudyingMvcCoreDbContext context) : base(context) { }

        public async Task<Customer> GetCustomerToDos(Guid id)
        {
            return await Db.Customers.AsNoTracking()
                .Include(c => c.ToDos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetCustomerAddress(Guid id)
        {
            return await Db.Customers.AsNoTracking()
                .Include(c => c.Address)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Customer> GetCustomerAdressToDos(Guid id)
        {
            return await Db.Customers.AsNoTracking()
                .Include(c => c.Address)
                .Include(c => c.ToDos)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
