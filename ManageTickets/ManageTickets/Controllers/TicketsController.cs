using Microsoft.AspNetCore.Mvc;
using ManageTickets.Models.Entities;
using ManageTickets.IRepositories;

namespace ManageTickets.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketsController(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        
        [HttpGet("GetTickets")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var tickets = await _ticketRepository.GetTicketsAsync(pageNumber, pageSize);
            return Ok(tickets);
        }


        [HttpPost("CreateTicket")]
        public async Task<ActionResult<Ticket>> CreateTicket([FromBody] Ticket ticket)
        {
            var createdTicket = await _ticketRepository.CreateTicketAsync(ticket);
            return  Ok(createdTicket);
        }

        [HttpPut("UpdateTicket/{id}")]
        public async Task<IActionResult> UpdateTicket(long id, [FromBody] Ticket ticket)
        {
            var updatedTicket = await _ticketRepository.UpdateTicketAsync(id, ticket);

            if (updatedTicket == null)
                return NotFound(); 

            return Ok(updatedTicket);
        }

        
        [HttpDelete("DeleteTicket/{id}")]
        public async Task<IActionResult> DeleteTicket(long id)
        {
            var result = await _ticketRepository.DeleteTicketAsync(id);

            if (!result)
                return NotFound();

            return Ok(new { message = $"Ticket with ID {id} has been successfully deleted." });
        }
    }
}
