using StudyingMvcCore.Business.Models;
using System;
using System.Threading.Tasks;

namespace StudyingMvcCore.Business.Interfaces
{
    public interface IToDoService : IDisposable
    {
        Task Add(ToDo toDo);
        Task Update(ToDo toDo);
        Task Remove(Guid id);
    }
}
