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

        public bool Succeeded { get; protected set; }
    }
    public class CalculateInterestSuccessQueryResponse : CalculateInterestQueryResponse
    {
        public CalculateInterestSuccessQueryResponse()
        {
            Succeeded = true;
        }
    }
    public class CalculateInterestErrorQueryResponse : CalculateInterestQueryResponse
    {
        public string Message { get; set; }
        public CalculateInterestErrorQueryResponse(string message) : this()
        {
            Message = message;
        }

        public CalculateInterestErrorQueryResponse()
        {
            Succeeded = false;
        }
    }
}
