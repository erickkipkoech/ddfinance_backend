namespace DDFinanceBackend.Models.Requests
{
    public class AddEditInsurancePoliciesRequest
    {
        public int PolicyId { get; set; } 
        public string PolicyName { get; set; } = string.Empty;
        public decimal PremiumAmount { get; set; }
        public string PolicyType { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
