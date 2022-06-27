using InterestApi.Abstract.Validation;

namespace InterestApi.Concrete.Validation
{
    public class ValidationResult : IValidationResult
    {
        public ValidationResult(bool succeeded, string message) : this(succeeded)
        {
            Message = message;
        }
        public ValidationResult(bool succeeded)
        {
            Succeeded = succeeded;
        }
        public string Message { get; }

        public bool Succeeded { get; }
    }
}
