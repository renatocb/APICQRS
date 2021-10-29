using CQRS.Application.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace CQRS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImoveisController : ControllerBase
    {
        private IMediator _mediator;

        public ImoveisController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetPortal([FromQuery] UrlQueryParameters _urlQueryParameters,
            CancellationToken cancellationToken)
        {

            var result = await _mediator.Send(new GetAllImoveisByPageQuery(_urlQueryParameters.Portal,
                                                                           _urlQueryParameters.Limit,
                                                                           _urlQueryParameters.Page));
            return Ok(result);
        }
        public record UrlQueryParameters(string Portal = "zap", int Limit = 1, int Page = 50);
    }
}
