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
        public int AmountPaid { get; set; }

        /// <summary>
        /// Kalan miktar
        /// </summary>
        public int RemainingAmount { get; set; }

        /// <summary>
        /// Ödenen faiz
        /// </summary>
        public int InterestPaid { get; set; }
    }
}
