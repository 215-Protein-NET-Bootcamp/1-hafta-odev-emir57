using InterestApi.Features.Queries.Interest;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InterestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public InterestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Calculate(CalculateInterestQueryRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> PaymentPlan(CalculateInterestQueryRequest request)
        {
            var response = await _mediator.Send(request);
            if (response.Succeeded == false)
                return Ok(response);
            return Ok(response);
        }
    }
}
