
namespace Validation
{
    internal class DateNotInFutureAttribute : Attribute
    {
        public string ErrorMessage { get; set; }
    }
}