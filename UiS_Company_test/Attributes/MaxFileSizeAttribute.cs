using System.ComponentModel.DataAnnotations;
using UiS_Company_test.Settings;

namespace UiS_Company_test.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int _maxSize;

        public MaxFileSizeAttribute(int maxSize)
        {
            _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file is not null)
            {


                if (file.Length > _maxSize)
                    return new ValidationResult($"Max Size Allowed is {FileSetting.MaxFileSizeInMB} MB!");
            }

            return ValidationResult.Success;
        }
    }
}
