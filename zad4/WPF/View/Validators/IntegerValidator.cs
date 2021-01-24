using System;
using System.Globalization;
using System.Windows.Controls;

namespace View.Validators
{
    class IntegerValidator : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            int i = 0;
            try
            {
                if (((string)value).Length > 0)
                    i = Int32.Parse((String)value);
            }
            catch (Exception)
            {
                return new ValidationResult(false, $"Enter non negative integer");
            }

            if (i >= 0)
            {
                return ValidationResult.ValidResult;
            }
            else
            {
                return new ValidationResult(false, $"Enter non negative integer");
            }
        }
    }
}
