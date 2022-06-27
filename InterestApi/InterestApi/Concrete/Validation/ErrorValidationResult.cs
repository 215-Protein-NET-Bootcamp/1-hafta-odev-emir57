namespace InterestApi.Concrete.Validation
{
    public class ErrorValidationResult : ValidationResult
    {
        public ErrorValidationResult() : base(false)
        {

        }
        public ErrorValidationResult(string message) : base(false, message)
        {

        }
    }
}
