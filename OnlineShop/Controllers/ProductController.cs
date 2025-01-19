using Microsoft.AspNetCore.Mvc;
using OnlineShop.BLL.Interfaces.ServicesInterfaces;
using OnlineShop.DAL.ViewModels;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        public async Task<IActionResult> Index(string searchTerm, int page = 1)
        {            
            int pageSize = 10;
            
            var products = await _productService.GetAllAsync();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                products = products.Where(p => p.Name.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            
            var paginatedProducts = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            
             int totalPages = (int)Math.Ceiling(products.Count() / (double)pageSize);

            var model = new ProductListViewModel
            {
                Products = paginatedProducts,
                CurrentPage = page,
                TotalPages = totalPages,
                SearchTerm = searchTerm
            };

            return View(model);
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetByIdAsync(id); 
            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new ProductViewModel
            {
                Categories = await _productService.GetCategoriesAsync(),
                Models = await _productService.GetModelsAsync()
            };

            return View(viewModel);
        }
       
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                model.Categories = await _productService.GetCategoriesAsync();
                model.Models = await _productService.GetModelsAsync();
                return View(model);
            }

            var product = new ProductViewModel
            {
                Name = model.Name,
                ProductNumber = model.ProductNumber,
                ProductCategoryId = model.ProductCategoryId,
                ProductModelId = model.ProductModelId,
                ListPrice = model.ListPrice
            };

            await _productService.CreateAsync(product);

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productService.GetByIdAsync(id); 
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.UpdateAsync(model); 
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            return View(product);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(ProductViewModel model)
        {
            await _productService.DeleteAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
