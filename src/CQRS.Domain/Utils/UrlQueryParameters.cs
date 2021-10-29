namespace CQRS.Domain.Utils
{
    public class UrlQueryParameters
    {
        public UrlQueryParameters(string portal, int page, int limit)
        {
            Portal = portal;
            Limit = limit;
            Page = page;
        }
        public string Portal { get; set; }
        public int Limit { get; set; }
        public int Page { get; set; }
    }
}