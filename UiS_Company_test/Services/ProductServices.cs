using Microsoft.EntityFrameworkCore;
using UiS_Company_test.Models;
using UiS_Company_test.Settings;
using UiS_Company_test.ViewModel;

namespace UiS_Company_test.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly string _imgPath;

        public ProductServices(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _imgPath = $"{_environment.WebRootPath}{FileSetting.imagesFolder}";
        }

        public IEnumerable<Product> GetAll()
        {

            return _context.Products
                .AsNoTracking()
                .ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products
                .AsNoTracking()
                .SingleOrDefault(g => g.Id == id);
        }

        public async Task Create(CreateProduct_ViewModel model)
        {
            var coverName = await SaveCover(model.Image);
            var generatedCode = Guid.NewGuid().ToString();
            Product product = new()
            {
                ProductName = model.ProductName,
                GeneratedCode = generatedCode,
                Image = coverName,
                Unit = model.Unit,
                Price = model.Price,
                InitialQuantity = model.InitialQuantity,

            };
            _context.Products.Add(product);
            _context.SaveChanges();
        }



        private async Task<string> SaveCover(IFormFile Cover)
        {
            var coverName = $"{Guid.NewGuid()}{Path.GetExtension(Cover.FileName)}";
            var path = Path.Combine(_imgPath, coverName);
            using var stream = File.Create(path);
            await Cover.CopyToAsync(stream);

            return coverName;
        }

     
    }
}
