using StudyingMvcCore.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyingMvcCore.Business.Interfaces
{
    public interface IToDoRepository : IRepository<ToDo>
    {
        Task<ToDo> GetToDoCustomer(Guid id);
        Task<IEnumerable<ToDo>> GetToDosCustomers();
    }
}
