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
        public Task<CalculateInterestQueryResponse> Handle(CalculateInterestQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
