using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudyingMvcCore.App.Extensions;
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
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomersController(ICustomerRepository customerRepository,
                                   ICustomerService customerService,
                                   IMapper mapper) 
        {
            _customerRepository = customerRepository;
            _customerService = customerService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<CustomerViewModel>>(await _customerRepository.GetAll()));
        }

        [AllowAnonymous]
        public async Task<IActionResult> Details(Guid id)
        {
            var customerViewModel = await GetCustomerAdressToDos(id);

            if (customerViewModel == null)
            {
                return NotFound();
            }

            return View(customerViewModel);
        }

        [ClaimsAuthorize("Customer", "Add")]
        public IActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Customer", "Add")]
        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid) return View(customerViewModel);

            var customer = _mapper.Map<Customer>(customerViewModel);
            await _customerService.Add(customer);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Customer", "Updt")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var customerViewModel = await GetCustomerAdressToDos(id);
            
            if (customerViewModel == null)
            {
                return NotFound();
            }
            
            return View(customerViewModel);
        }

        [ClaimsAuthorize("Customer", "Updt")]
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, CustomerViewModel customerViewModel)
        {
            if (id != customerViewModel.Id) return NotFound();

            if (!ModelState.IsValid) return View(customerViewModel);

            var customer = _mapper.Map<Customer>(customerViewModel);
            await _customerService.Update(customer);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Customer", "Del")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customerViewModel = await GetCustomerToDos(id);
            
            if (customerViewModel == null) return NotFound();
            
            return View(customerViewModel);
        }

        [ClaimsAuthorize("Customer", "Del")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var customerViewModel = await GetCustomerToDos(id);

            if (customerViewModel == null) return NotFound();

            await _customerService.Remove(id);

            return RedirectToAction(nameof(Index));
        }

        [ClaimsAuthorize("Customer", "Updt")]
        public async Task<IActionResult> UpdateAddress(Guid id)
        {
            var customer = await GetCustomerAddress(id);

            if (customer == null) return NotFound();

            return PartialView("_UpdateAddress", new CustomerViewModel { Address = customer.Address });
        }

        [ClaimsAuthorize("Customer", "Updt")]
        [HttpPost]
        public async Task<IActionResult> UpdateAddress(CustomerViewModel customerViewModel)
        {
            ModelState.Remove("Name");
            ModelState.Remove("Email");

            if (!ModelState.IsValid) return PartialView("_UpdateAddress", customerViewModel);

            await _customerService.UpdateAddress(_mapper.Map<Address>(customerViewModel.Address));

            var url = Url.Action("GetAddress", "Customers", new { id = customerViewModel.Address.CustomerId});
            return Json(new { success = true, url });
        }

        [AllowAnonymous]
        public async Task<IActionResult> GetAddress(Guid id)
        {
            var customer = await GetCustomerAddress(id);

            if (customer == null) return NotFound();

            return PartialView("_AddressDetails", customer);
        }

        private async Task<CustomerViewModel> GetCustomerToDos(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerRepository.GetCustomerToDos(id));
        }

        private async Task<CustomerViewModel> GetCustomerAdressToDos(Guid id)
        {
            return _mapper.Map<CustomerViewModel>( await _customerRepository.GetCustomerAdressToDos(id));
        }

        private async Task<CustomerViewModel> GetCustomerAddress(Guid id)
        {
            return _mapper.Map<CustomerViewModel>( await _customerRepository.GetCustomerAddress(id));
        }
    }
}
