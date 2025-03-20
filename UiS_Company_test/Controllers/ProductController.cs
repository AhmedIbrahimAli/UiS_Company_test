using Microsoft.AspNetCore.Mvc;
using UiS_Company_test.Models;
using UiS_Company_test.Services;
using UiS_Company_test.ViewModel;

namespace UiS_Company_test.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductServices _productServices;
        private readonly ITransactionServices _transactionServices;

        public ProductController(IProductServices productServices, ITransactionServices transactionServices)
        {
            _productServices = productServices;
            _transactionServices = transactionServices;
            
        }

        // GET: Product/Create
        public IActionResult Create()
        {
          
          
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProduct_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productServices.Create(model);
                return RedirectToAction(nameof(Create));
            }
            return View(model);
        }
    }
}
