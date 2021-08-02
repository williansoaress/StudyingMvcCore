using StudyingMvcCore.Business.Interfaces;
using StudyingMvcCore.Business.Models;
using System;
using System.Threading.Tasks;

namespace StudyingMvcCore.Business.Services
{
    public class ToDoService : BaseService, IToDoService
    {
        private readonly IToDoRepository _toDoRepository;

        public ToDoService(IToDoRepository toDoRepository)
        {
            _toDoRepository = toDoRepository;
        }

        public async Task Add(ToDo toDo)
        {
            await _toDoRepository.Add(toDo);
        }

        public async Task Update(ToDo toDo)
        {
            await _toDoRepository.Update(toDo);
        }

        public async Task Remove(Guid id)
        {
            await _toDoRepository.Remove(id);
        }

        public void Dispose()
        {
            _toDoRepository?.Dispose();
        }
    }
}
