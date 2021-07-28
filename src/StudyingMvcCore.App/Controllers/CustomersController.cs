using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudyingMvcCore.App.ViewModels;
using StudyingMvcCore.Business.Interfaces;
using StudyingMvcCore.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudyingMvcCore.App.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository,
                                   IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll()));
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var customerViewModel = await GetCustomerToDos(id);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);

            var customer = _mapper.Map<Customer>(customerViewModel);
            await _customerRepository.Add(customer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var customerViewModel = await GetCustomerToDos(id);
            
            if (customerViewModel == null)
            {
                return NotFound();
            }
            
            return View(customerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(customerViewModel);

            var customer = _mapper.Map<Customer>(customerViewModel);
            await _customerRepository.Update(customer);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var customerViewModel = await GetCustomerToDos(id);
            
            if (customerViewModel == null) return NotFound();
            
            return View(customerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerViewModel = await GetCustomerToDos(id);

            if (customerViewModel == null) return NotFound();

            await _customerRepository.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<CustomerViewModel> GetCustomerToDos(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomerToDos(id));
        }
        
    }
}
