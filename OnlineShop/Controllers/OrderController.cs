using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerService _customerService;

        public OrderController(IOrderService orderService, ICustomerService customerService)
        {
            _orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }


        public async Task<IActionResult> Index(string searchTerm = "", int page = 1)
        {
            var orders = await _orderService.GetAllAsync();
            var totalOrders = orders.Count();
            var pageSize = 10;
            var totalPages = (int)Math.Ceiling(totalOrders / (double)pageSize);

            var orderListViewModel = new OrderListViewModel
            {
                Orders = orders.Skip((page - 1) * pageSize).Take(pageSize),
                CurrentPage = page,
                TotalPages = totalPages,
                SearchTerm = searchTerm
            };

            return View(orderListViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {            
            var order = await _orderService.GetByIdAsync(id);

            if (order == null)
            {              
                return NotFound();
            }

            return View(order);
        }

        public async Task<IActionResult> Create()
        {
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            return View(new OrderViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderService.CreateAsync(model);
                return RedirectToAction(nameof(Index));
            }
            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;

            return View(order);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _orderService.UpdateAsync(model);
                return RedirectToAction(nameof(Index));
            }

            var customers = await _customerService.GetAllAsync();
            ViewBag.Customers = customers;
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _orderService.GetByIdAsync(id);
            if (order != null)
            {
                await _orderService.DeleteAsync(order);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
