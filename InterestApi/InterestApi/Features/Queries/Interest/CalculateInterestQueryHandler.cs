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
                var result = RunValidations(
                    CheckNullDesiredAmount(request.DesiredAmount),
                    CheckNegativeDesiredAmount(request.DesiredAmount),
                    CheckNullMaturityAmount(request.MaturityAmount),
                    CheckNegativeMaturityAmount(request.MaturityAmount)
                    );
                if (result != null)
                    return result;
                int totalPrice = request.DesiredAmount * _interestOptions.InterestRate / 100 * request.MaturityAmount;
                return new CalculateInterestSuccessQueryResponse
                {
                    TotalPaymentAmount = totalPrice,
                    TotalInterestAmount = totalPrice - request.DesiredAmount
                };
            });
        }
        /// <summary>
        /// Validasyon metotlarını çalıştırır. Sonuç false olursa hata objesini döndürür aksi halde null döndürür.
        /// </summary>
        /// <param name="logics">Validasyon Metotları</param>
        /// <returns></returns>
        private CalculateInterestQueryResponse RunValidations(params CalculateInterestQueryResponse[] logics)
        {
            foreach (var logic in logics)
                if (logic.Succeeded == false)
                    return logic;

            return null;
        }
        /// <summary>
        /// İstenen miktar null veya sıfır ise hata döndürür
        /// </summary>
        /// <param name="desiredAmount">İstenen Miktar</param>
        /// <returns></returns>
        private CalculateInterestQueryResponse CheckNullDesiredAmount(int desiredAmount)
        {
            if (desiredAmount == null || desiredAmount == 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.DesiredAmountNullError);
            return new CalculateInterestSuccessQueryResponse();
        }
        /// <summary>
        /// Istenen miktar sıfırdan küçük ise hata döndürür
        /// </summary>
        /// <param name="desiredAmount">İstene Miktar</param>
        /// <returns></returns>
        private CalculateInterestQueryResponse CheckNegativeDesiredAmount(int desiredAmount)
        {
            if (desiredAmount < 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.DesiredAmountNegativeError);
            return new CalculateInterestSuccessQueryResponse();
        }
        /// <summary>
        /// Vade tutarı null veya 0 ise hata döndürür
        /// </summary>
        /// <param name="maturityAmount">Vade Tutarı</param>
        /// <returns></returns>
        private CalculateInterestQueryResponse CheckNullMaturityAmount(int maturityAmount)
        {
            if (maturityAmount == null || maturityAmount == 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.MaturityAmountNullError);
            return new CalculateInterestSuccessQueryResponse();
        }
        /// <summary>
        /// Vade tutarı sıfırdan küçük ise hata döndürür
        /// </summary>
        /// <param name="maturityAmount">Vade Tutarı</param>
        /// <returns></returns>
        private CalculateInterestQueryResponse CheckNegativeMaturityAmount(int maturityAmount)
        {
            if (maturityAmount < 0)
                return new CalculateInterestErrorQueryResponse(_interestOptions.MaturityAmountNegativeError);
            return new CalculateInterestSuccessQueryResponse();
        }
    }
}
