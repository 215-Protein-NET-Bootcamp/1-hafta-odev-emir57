namespace InterestApi.Features.Queries.Interest
{
    public class CalculateInterestQueryResponse
    {
        /// <summary>
        /// Toplam ödeme tutarı
        /// </summary>
        public int TotalPaymentAmount { get; set; }

        /// <summary>
        /// Toplam faiz tutarı
        /// </summary>
        public int TotalInterestAmount { get; set; }
    }
}
