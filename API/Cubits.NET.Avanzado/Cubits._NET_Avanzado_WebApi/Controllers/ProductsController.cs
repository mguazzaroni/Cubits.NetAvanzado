using Cubits.NET.Avanzado.Application.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cubits.NET.Avanzado.WebApi.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetList([FromQuery] GetProductListRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var request = new GetProductRequest
            { 
                Id = id 
            };

            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}
