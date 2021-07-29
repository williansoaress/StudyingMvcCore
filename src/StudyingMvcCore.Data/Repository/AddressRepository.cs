using StudyingMvcCore.Business.Interfaces;
using StudyingMvcCore.Business.Models;
using StudyingMvcCore.Data.Context;

namespace StudyingMvcCore.Data.Repository
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        public AddressRepository(StudyingMvcCoreDbContext context) : base(context) { }
    }
}
