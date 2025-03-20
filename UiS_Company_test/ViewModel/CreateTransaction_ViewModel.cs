namespace UiS_Company_test.ViewModel
{
    public class CreateTransaction_ViewModel
    {
        public string Product_Name { get; set; } = default!;
        public string Image { get; set; } = default!;
        public float Quantity { get; set; }
        public float InitialQuantity { get; set; }
        public DateTime Date { get; set; }
        public string Unit { get; set; } = default!;
        public float Price { get; set; }
        public float Total_Price { get; set; }
    }
}
