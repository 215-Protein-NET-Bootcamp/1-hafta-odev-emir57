﻿namespace InterestApi.Entities
{
    public class InterestsOptions
    {
        public byte InterestRate { get; set; }
        public string DesiredAmountNullError { get; set; }
        public string DesiredAmountNegativeError { get; set; }
        public string MaturityAmountNullError { get; set; }
        public string MaturityAmountNegativeError { get; set; }
    }
}
