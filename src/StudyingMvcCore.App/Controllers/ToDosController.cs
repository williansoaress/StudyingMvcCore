using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StudyingMvcCore.App.ViewModels;
using StudyingMvcCore.Business.Interfaces;
using StudyingMvcCore.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyingMvcCore.App.Controllers
{
    public class ToDosController : BaseController
    {
        private readonly IToDoRepository _toDoRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ToDosController(IToDoRepository toDoRepository,
                               ICustomerRepository customerRepository,
                               IMapper mapper)
        {
            _toDoRepository = toDoRepository;
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(await GetToDosCustomers());
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var toDoViewModel = await GetToDoCustomer(id);

            if (toDoViewModel == null)
            {
                return NotFound();
            }

            return View(toDoViewModel);
        }

        public async Task<IActionResult> Create()
        {
            var todoViewModel = await PopulateCustomers(new ToDoViewModel());

            return View(todoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDoViewModel toDoViewModel)
        {
            toDoViewModel = await PopulateCustomers(toDoViewModel);
            if (!ModelState.IsValid) return View(toDoViewModel);

            var toDo = _mapper.Map<ToDo>(toDoViewModel);
            await _toDoRepository.Add(toDo);

            return View(toDoViewModel);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var toDoViewModel = await GetToDoCustomer(id);
            
            if (toDoViewModel == null) return NotFound();
            return View(toDoViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, ToDoViewModel toDoViewModel)
        {
            if (id != toDoViewModel.Id) return NotFound();

            var toDoUpdate = await GetToDoCustomer(id);
            toDoViewModel.Customer = toDoUpdate.Customer;

            if (!ModelState.IsValid) return View(toDoViewModel);

            toDoUpdate.Description = toDoViewModel.Description;
            toDoUpdate.DueDate = toDoViewModel.DueDate;

            await _toDoRepository.Update(_mapper.Map<ToDo>(toDoUpdate));

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var toDoViewModel = await GetToDoCustomer(id);

            if (toDoViewModel == null)
            {
                return NotFound();
            }

            return View(toDoViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var toDoViewModel = await GetToDoCustomer(id);

            if (toDoViewModel == null) return NotFound();

            await _toDoRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<ToDoViewModel> PopulateCustomers(ToDoViewModel toDoViewModel)
        {
            toDoViewModel.Customers = _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll());
            return toDoViewModel;
        }

        private async Task<IEnumerable<ToDoViewModel>> GetToDosCustomers()
        {
            return _mapper.Map<IEnumerable<ToDoViewModel>>( await _toDoRepository.GetToDosCustomers());
        }

        private async Task<ToDoViewModel> GetToDoCustomer(Guid id)
        {
            return _mapper.Map<ToDoViewModel>(await _toDoRepository.GetToDoCustomer(id));
        }

    }
}
