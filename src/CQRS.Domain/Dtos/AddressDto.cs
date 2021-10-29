namespace CQRS.Domain.Dtos
{
    public class AddressDto
    {        
        public string City { get; set; }
        public string Neighborhood { get; set; }
        public GeoLocationDto GeoLocation { get; set; }

    }
}