using System.Collections.Generic;

namespace CQRS.Domain.Dtos
{
    public record GetImoveisListResponseDto
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
        public int TotalCount { get; init; }
        public int TotalPages { get; init; }
        public List<ImoveisDto> Listings { get; init; }
    }
}