using CQRS.Domain.Dtos;
using CQRS.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Domain.Interfaces
{
    public interface IZapImoveisRepository
    {
        Task<GetImoveisListResponseDto> GetByPageAsync(int limit, int page,
                                                        CancellationToken cancellationToken);        
        IQueryable<Imoveis> SaleRules();
        IQueryable<Imoveis> RentalRules();
    }
}
