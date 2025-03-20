namespace UiS_Company_test.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string Product_Name { get; set; } = default!;
        public string Image { get; set; } = default!;
        public float Quantity { get; set; } 
        public DateTime Date { get; set; }
        public string Unit { get; set; } = default!;
        public float Total_Price { get; set; }



        public ICollection<Product> Products { get; set; } = default!;
            
    }
}
