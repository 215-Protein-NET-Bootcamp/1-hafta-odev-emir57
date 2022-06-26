using MediatR;

namespace InterestApi.Features.Queries
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
