using Microsoft.EntityFrameworkCore;
using StudyingMvcCore.Business.Interfaces;
using StudyingMvcCore.Business.Models;
using StudyingMvcCore.Data.Context;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyingMvcCore.Data.Repository
{
    public class ToDoRepository : Repository<ToDo>, IToDoRepository
    {
        public ToDoRepository(StudyingMvcCoreDbContext context) : base(context) { }

        public async Task<ToDo> GetToDoCustomer(Guid id)
        {
            return await Db.ToDos.AsNoTracking()
                .Include(c => c.Customer)
                .FirstAsync(t => t.Id == id);
        }

        public async Task<IEnumerable<ToDo>> GetToDosCustomers()
        {
            return await Db.ToDos.AsNoTracking()
                .Include(c => c.Customer)
                .ToListAsync();
        }
    }
}
