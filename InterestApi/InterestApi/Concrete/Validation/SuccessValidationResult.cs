namespace InterestApi.Concrete.Validation
{
    public class SuccessValidationResult : ValidationResult
    {
        public SuccessValidationResult() : base(true)
        {

        }
        public SuccessValidationResult(string message) : base(true, message)
        {

        }
    }
}
