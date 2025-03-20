using System.ComponentModel.DataAnnotations;

namespace UiS_Company_test.ViewModel
{
    public class CreateProduct_ViewModel
    {
        [Display(Name ="Product Name")]
        public string ProductName { get; set; } = default!;
        public IFormFile Image { get; set; } = default!;
        public string Unit { get; set; } = default!;
        public float Price { get; set; }
        [Display(Name = "Initial Quantity")]
        public float InitialQuantity { get; set; }
    }
}
