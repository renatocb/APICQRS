using CQRS.Application.Services.Notifications;
using CQRS.Domain.Dtos;
using CQRS.Domain.Interfaces;
using CQRS.Domain.Utils;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.Application.Services.Queries
{
    public class GetAllImoveisByPageQuery : IRequest<GetImoveisListResponseDto>
    {
        public UrlQueryParameters urlQueryParameters { get; set; }

        public GetAllImoveisByPageQuery(string portal, int limit, int page)
        {
            urlQueryParameters = new UrlQueryParameters(portal, page, limit);
        }
    }
    public class GetAllImoveisQueryQueryHandler : IRequestHandler<GetAllImoveisByPageQuery,
                 GetImoveisListResponseDto>
    {
        private readonly IZapImoveisRepository _zapRepository;
        private readonly IVivaRealImoveisRepository _vivaRealRepository;
        private readonly IMediator _mediator;

        public GetAllImoveisQueryQueryHandler(IZapImoveisRepository zapRepository,
                                              IVivaRealImoveisRepository vivaRealRepository,
                                              IMediator mediator)
        {
            _zapRepository = zapRepository;
            _vivaRealRepository = vivaRealRepository;
            _mediator = mediator;
        }
        public async Task<GetImoveisListResponseDto> Handle(GetAllImoveisByPageQuery request,
            CancellationToken cancellationToken)
        {
            GetImoveisListResponseDto imoveis = new GetImoveisListResponseDto();

            try
            {
                if (request.urlQueryParameters.Portal.Equals("zap"))
                    imoveis = await _zapRepository.GetByPageAsync(request.urlQueryParameters.Limit,
                                                                  request.urlQueryParameters.Page,
                                                                  cancellationToken);
                else
                    imoveis = await _vivaRealRepository.GetByPageAsync(request.urlQueryParameters.Limit,
                                                                       request.urlQueryParameters.Page,
                                                                       cancellationToken);
                if (imoveis == null)
                {
                    await _mediator.Publish(new ErrorNotification
                    {
                        Error = "Imoveis List cannot be found",
                        Stack = "imoveisList is null"
                    }, cancellationToken);
                    return null;
                }

                return imoveis;
            }
            catch (Exception ex)
            {
                return imoveis;
            }
        }
    }
}

