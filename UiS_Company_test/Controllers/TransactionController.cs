using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UiS_Company_test.Models;
using UiS_Company_test.Services;
using UiS_Company_test.ViewModel;

namespace UiS_Company_test.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionServices _transactionServices;
        private readonly IProductServices _productServices;
        public TransactionController(ITransactionServices transactionServices, IProductServices productServices)
        {
            _transactionServices = transactionServices;
            _productServices = productServices;
        }
        public IActionResult Index()
        {
            var Transactions = _transactionServices.GetAll();

            return View(Transactions);
        }
        [HttpGet]
        public IActionResult Create(int Id)
        {
            var product = _productServices.GetById(Id);
            
            if (product == null) 
                return NotFound();

            CreateTransaction_ViewModel Show_Product = new ()
            {
               Product_Name = product.ProductName,
               Image = product.Image,
               Price = product.Price,
               Unit = product.Unit, 
               InitialQuantity = product.InitialQuantity

            };
           
            return View(Show_Product);
        }
        [HttpPost]
        public IActionResult Create(CreateTransaction_ViewModel model)
        {
            if (ModelState.IsValid)
            {
                 _transactionServices.Create(model);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }



        [HttpDelete]
        public bool Delete(int Id)
        {
            return _transactionServices.Delete(Id);
        }
    }
}
