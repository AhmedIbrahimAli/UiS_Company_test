using UiS_Company_test.Models;
using UiS_Company_test.ViewModel;

namespace UiS_Company_test.Services
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAll();
        Task Create(CreateProduct_ViewModel product);
        Product? GetById(int id);
    }
}
