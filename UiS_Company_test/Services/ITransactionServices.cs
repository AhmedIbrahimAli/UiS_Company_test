using UiS_Company_test.Models;
using UiS_Company_test.ViewModel;
namespace UiS_Company_test.Services
{
    public interface ITransactionServices
    {
        IEnumerable<Transaction> GetAll();
        Transaction? GetById(int id);
        void Create(CreateTransaction_ViewModel Transaction);
        void Edit(Transaction Transaction);
        bool Delete(int id);

    }
}
