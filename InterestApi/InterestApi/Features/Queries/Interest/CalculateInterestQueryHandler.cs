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
                int total = request.DesiredAmount * _interestOptions.InterestRate * request.MaturityAmount;
                return new CalculateInterestSuccessQueryResponse
                {
                    TotalPaymentAmount = total,
                    TotalInterestAmount = total - request.DesiredAmount
                };
            });
        }
    }
}
