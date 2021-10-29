using System.Text.Json.Serialization;

namespace CQRS.Domain.Dtos
{
    public class PricingInfosDto
    {
        [JsonIgnore(Condition = (System.Text.Json.Serialization.JsonIgnoreCondition)JsonIgnoreCondition.WhenWritingDefault)]
        public string YearlyIptu { get; set; }
        public string Price { get; set; }
        [JsonIgnore(Condition = (System.Text.Json.Serialization.JsonIgnoreCondition)JsonIgnoreCondition.WhenWritingDefault)]
        public string RentalTotalPrice { get; set; }
        public string BusinessType { get; set; }
        [JsonIgnore(Condition = (System.Text.Json.Serialization.JsonIgnoreCondition)JsonIgnoreCondition.WhenWritingDefault)]
        public string MonthlyCondoFee { get; set; }
    }
}