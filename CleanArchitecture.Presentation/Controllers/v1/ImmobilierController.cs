using Asp.Versioning;
using CleanArchitecture.Application.Features.Immobilier.Commands.CreateImmobilier;
using CleanArchitecture.Application.Features.Immobilier.Queries.GetAllImmobilier;
using CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierById;
using CleanArchitecture.Application.Features.Immobilier.Queries.GetImmobilierByReff;
using CleanArchitecture.Application.Mappers;
using CleanArchitecture.Domain.Models;
using CleanArchitecture.Domain.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArchitecture.Presentation.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    [ApiController]
    public class ImmobilierController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ImmobilierController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<ImmobilierController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            ServiceResponse<List<Immobilier>> response=new();
            response = await _mediator.Send(new GetAllImmobilierQuery());
            return response.Success == true ? Ok(response) : BadRequest(response);
        }

        // GET: api/<ImmobilierController>
        [HttpGet("published/{published}")]
        public async Task<IActionResult> GetPushed(bool published)
        {
            var response = await _mediator.Send(new GetAllImmobilierQuery(published));
            return response.Success == true ? Ok(response) : BadRequest(response);
        }

        // GET api/<ImmobilierController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            ServiceResponse<Immobilier> response = await _mediator.Send(new GetImmobilierByIdQuery(id));
            return response.Success == true ? Ok(response) : BadRequest(response);
        }

        // GET api/<ImmobilierController>/reference/5
        [HttpGet("reference/{reff}")]
        public async Task<IActionResult> GetByRefference(string reff)
        {
            ServiceResponse<Immobilier> response = await _mediator.Send(new GetImmobilierByReffQuery(reff));
            return response.Success == true ? Ok(response) : BadRequest(response);
        }

        // POST api/<ImmobilierController>
        [HttpPost]
        public async Task<IActionResult> Post(ImmobilierDto immobilier)
        {
            //ServiceResponse<Immobilier> response = new();

         var   response= await _mediator.Send(new CreateImmobilierCommand(immobilier));

            return response.Success==true?Ok(response):BadRequest(response);

        }

        // PUT api/<ImmobilierController>/5
        [HttpPut("{id}")]
        public void Put(int id, ImmobilierDto immobilier)
        {
            throw new NotImplementedException();
        }

        // DELETE api/<ImmobilierController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            throw new NotImplementedException();
        }


    }
}
