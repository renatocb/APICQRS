using System;

namespace CQRS.Domain.Entities
{
    public class Imoveis
    {
        public int UsableAreas { get; set; }
        public string ListingType { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ListingStatus { get; set; }
        public string Id { get; set; }
        public int ParkingSpaces { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool Owner { get; set; }
        public string[] Images { get; set; }
        public Address Address { get; set; }
        public int BathRooms { get; set; }
        public int BedRooms { get; set; }
        public PricingInfos PricingInfos { get; set; }           

    }
}
