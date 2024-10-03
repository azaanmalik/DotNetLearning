using System.ComponentModel.DataAnnotations;

namespace UserRegisteration.Validation
{
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime? Date_of_Birth = value as DateTime?;

            if (Date_of_Birth.HasValue && Date_of_Birth.Value > DateTime.Now)
            {
                return false;
            }

            return true;
        }
    }
}