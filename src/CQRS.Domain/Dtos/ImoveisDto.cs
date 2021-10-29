using System;
using CQRS.Domain.Dtos;

namespace CQRS.Domain.Dtos
{
    public class ImoveisDto
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
        public AddressDto Address { get; set; }
        public int BathRooms { get; set; }
        public int BedRooms { get; set; }
        public PricingInfosDto PricingInfos { get; set; }
    }

}