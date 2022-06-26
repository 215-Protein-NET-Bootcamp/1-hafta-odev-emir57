using MediatR;

namespace InterestApi.Features.Queries.Interest
{
    public class CalculateInterestQueryHandler : IRequestHandler<CalculateInterestQueryRequest, CalculateInterestQueryResponse>
    {
        public Task<CalculateInterestQueryResponse> Handle(CalculateInterestQueryRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
