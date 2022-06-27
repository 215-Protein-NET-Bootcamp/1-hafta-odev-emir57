namespace InterestApi.Responses
{
    public class CalculateInterestResponse
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
