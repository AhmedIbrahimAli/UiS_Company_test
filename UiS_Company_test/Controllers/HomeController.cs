using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UiS_Company_test.Models;
using UiS_Company_test.Services;

namespace UiS_Company_test.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductServices _productServices;

        public HomeController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public IActionResult Index()
        {
            var products = _productServices.GetAll();
            return View(products);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
