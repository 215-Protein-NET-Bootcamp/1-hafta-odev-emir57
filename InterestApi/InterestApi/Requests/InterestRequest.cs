namespace InterestApi.Requests
{
    public class InterestRequest
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
