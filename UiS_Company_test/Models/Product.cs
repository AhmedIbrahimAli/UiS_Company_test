using System.ComponentModel.DataAnnotations.Schema;

namespace UiS_Company_test.Models
{
    public class Product
    {
        public int Id { get; set; } // Primary key
        public string GeneratedCode { get; set; } = default!; // Automatically generated unique identifier
        public string ProductName { get; set; } = default!;
        public string Image { get; set; } = default!;
        public string Unit { get; set; } = default!;
        public float Price { get; set; }
        public float InitialQuantity { get; set; }


    }
}
