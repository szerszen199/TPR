using System.Globalization;
using System.Windows.Controls;

namespace View.Validators
{
    class StringValidator : ValidationRule
    {
        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string s = ((string)value);
            if (s.Length >= Min && s.Length <= Max)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, $"Validation Error");
            }
        }
    }
}
