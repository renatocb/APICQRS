using CQRS.Domain.Dtos;
using CQRS.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Domain.Interfaces
{
    public interface IVivaRealImoveisRepository
    {
        Task<GetImoveisListResponseDto> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
        IQueryable<Imoveis> SaleRules();
        IQueryable<Imoveis> RentalRules();
    }
}
