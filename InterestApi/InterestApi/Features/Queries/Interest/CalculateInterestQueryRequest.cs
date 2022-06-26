using MediatR;

namespace InterestApi.Features.Queries.Interest
{
    public class CalculateInterestQueryRequest : IRequest<CalculateInterestQueryResponse>
    {
        /// <summary>
        /// Vade Tutarı
        /// </summary>
        public int MaturityAmount { get; set; }

        /// <summary>
        /// İstenen Miktar
        /// </summary>
        public int DesiredAmount { get; set; }
    }
}
