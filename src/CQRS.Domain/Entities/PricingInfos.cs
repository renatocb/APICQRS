using System.Text.Json.Serialization;

namespace CQRS.Domain.Entities
{
    public class PricingInfos
    {   
        public string YearlyIptu { get; set; }
        public string Price { get; set; }
        public string RentalTotalPrice { get; set; }
        public string BusinessType { get; set; }        
        public string MonthlyCondoFee { get; set; }
    }
}