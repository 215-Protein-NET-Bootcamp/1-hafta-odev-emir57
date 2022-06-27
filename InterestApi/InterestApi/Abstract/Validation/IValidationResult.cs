namespace InterestApi.Abstract.Validation
{
    public interface IValidationResult
    {
        bool Succeeded { get; }
        string Message { get; }
    }
}
