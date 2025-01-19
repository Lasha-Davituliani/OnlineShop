using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<IActionResult> Index(string searchTerm, int page = 1)
        {
            int pageSize = 10;
            var customers = await _customerService.GetAllAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                customers = customers.Where(c => c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)|| 
                c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            var paginatedCustomers = customers.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalPages = (int)Math.Ceiling(customers.Count() / (double)pageSize);

            var model = new CustomerListViewModel
            {
                Customers = paginatedCustomers,
                CurrentPage = page,
                TotalPages = totalPages,
                SearchTerm = searchTerm
            };

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return View(customer);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new CustomerViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }

            await _customerService.CreateAsync(model);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return View(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _customerService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(CustomerViewModel model)
        {
            await _customerService.DeleteAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
