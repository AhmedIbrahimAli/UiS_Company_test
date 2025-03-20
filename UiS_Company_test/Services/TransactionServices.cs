
using Microsoft.EntityFrameworkCore;
using System;
using UiS_Company_test.Models;
using UiS_Company_test.Settings;
using UiS_Company_test.ViewModel;

namespace UiS_Company_test.Services
{
    public class TransactionServices : ITransactionServices
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly string _imgPath;

        public TransactionServices(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            _imgPath = $"{_environment.WebRootPath}{FileSetting.imagesFolder}";
        }

       

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transactions
                .Include(g => g.Products)
                .AsNoTracking ()
                .ToList ();
        }

        public Transaction? GetById(int id)
        {
            return _context.Transactions
                .AsNoTracking()
                .SingleOrDefault(g=> g.Id == id);
        }

        public  void Create(CreateTransaction_ViewModel model)
        {
             Transaction transaction = new()
            {
                Product_Name = model.Product_Name,
                Image = model.Image,
                Quantity = model.Quantity,
                Date = model.Date,
                Unit = model.Unit,
                Total_Price = model.Total_Price

            };

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            
        }

        public bool Delete(int Id )
        {
            bool isDeleted = false;
            var transaction = GetById(Id);

            if (transaction is null)
                return isDeleted;

            _context.Transactions.Remove(transaction);

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
                var cover = Path.Combine(_imgPath, transaction.Image!);
                File.Delete(cover);
            }
            return isDeleted;
        }

       
    }
}
