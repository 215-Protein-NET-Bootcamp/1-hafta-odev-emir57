namespace InterestApi.Responses
{
    public class CalculateInterestResponse
    {
        /// <summary>
        /// Toplam ödeme tutarı
        /// </summary>
        public double TotalPaymentAmount { get; set; }

        /// <summary>
        /// Toplam faiz tutarı
        /// </summary>
        public double TotalInterestAmount { get; set; }
    }
}
