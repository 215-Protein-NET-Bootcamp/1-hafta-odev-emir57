using InterestApi.Entities;
using MediatR;

namespace InterestApi.Features.Queries.Interest
{
    public class CalculateInterestQueryHandler : IRequestHandler<CalculateInterestQueryRequest, CalculateInterestQueryResponse>
    {
        private InterestsOptions _interestOptions;
        public CalculateInterestQueryHandler(IConfiguration configuration)
        {
            _interestOptions = configuration.GetSection("InterestsOptions").Get<InterestsOptions>();
        }
        public async Task<CalculateInterestQueryResponse> Handle(CalculateInterestQueryRequest request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                int totalPrice = request.DesiredAmount * _interestOptions.InterestRate / 100 * request.MaturityAmount;
                return new CalculateInterestSuccessQueryResponse
                {
                    TotalPaymentAmount = totalPrice,
                    TotalInterestAmount = totalPrice - request.DesiredAmount
                };
            });
        }

        private CalculateInterestQueryResponse RunValidations(params CalculateInterestQueryResponse[] logics)
        {
            foreach (var logic in logics)
            {
                if (logic.Succeeded == false)
                    return logic;
            }
            return null;
        }

        private CalculateInterestQueryResponse CheckNullDesiredAmount(int desiredAmount)
        {
            if (desiredAmount == null || desiredAmount == 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.DesiredAmountNullError);
            return new CalculateInterestSuccessQueryResponse();
        }

        private CalculateInterestQueryResponse CheckNegativeDesiredAmount(int desiredAmount)
        {
            if (desiredAmount < 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.DesiredAmountNegativeError);
            return new CalculateInterestSuccessQueryResponse();
        }

        private CalculateInterestQueryResponse CheckNullMaturityAmount(int maturityAmount)
        {
            if (maturityAmount == null || maturityAmount == 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.MaturityAmountNullError);
            return new CalculateInterestSuccessQueryResponse();
        }

        private CalculateInterestQueryResponse CheckNegativeMaturityAmount(int maturityAmount)
        {
            if (maturityAmount < 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.MaturityAmountNegativeError);
            return new CalculateInterestSuccessQueryResponse();
        }
    }
}
