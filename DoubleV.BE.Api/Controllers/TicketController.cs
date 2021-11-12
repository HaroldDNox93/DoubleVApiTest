using DoubleV.BE.Api.Helpers.Pagination;
using DoubleV.BE.Api.Helpers.Request;
using DoubleV.BE.Api.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DoubleV.BE.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _repository;

        public TicketController(ITicketRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTicketsPagination([FromQuery] Pagination pagination, CancellationToken cancellationToken)
        {
            var resp = await _repository.GetAllTicketsPagination(pagination, cancellationToken);
            return Ok(resp);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTicketById(int id)
        {
            var resp = await _repository.GetTicketById(id);
            if (resp == null) return NotFound();
            return Ok(resp);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTicket(CreateTicketRequest request)
        {
            var resp = await _repository.CreateTicket(request);
            if (resp == null) return BadRequest(request);
            return CreatedAtAction(nameof(GetTicketById), new { id = resp });
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateTicket(int id, CreateTicketRequest request)
        {
            var resp = await _repository.UpdateTicket(id, request);
            if (resp == null) return NotFound();
            return Ok(resp);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteTicketById(int id)
        {
            var resp = await _repository.DeleteTicket(id);
            if (resp == null) return NotFound();
            return NoContent();
        }
    }
}
