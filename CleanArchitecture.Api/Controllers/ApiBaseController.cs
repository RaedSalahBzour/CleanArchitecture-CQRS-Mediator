using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiBaseController : ControllerBase
    {
        private ISender _mediator;
        protected ISender mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
