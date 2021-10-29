namespace CQRS.Domain.Dtos
{
    public class GeoLocationDto
    {            
        public string Precision { get; set; }
        public LocationDto Location { get; set; }
    }
}