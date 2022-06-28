namespace InterestApi.Entities
{
    public class PaymentPlan
    {
        /// <summary>
        /// Dönem
        /// </summary>
        public byte Period { get; set; }

        /// <summary>
        /// Aylık ödenen miktar
        /// </summary>
        public double AmountPaid { get; set; }

        /// <summary>
        /// Kalan miktar
        /// </summary>
        public double RemainingAmount { get; set; }

        /// <summary>
        /// Ödenen faiz
        /// </summary>
        public double InterestPaid { get; set; }
    }
}
