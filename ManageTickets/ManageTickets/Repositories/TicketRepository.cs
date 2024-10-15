using ManageTickets.Data;
using ManageTickets.IRepositories;
using ManageTickets.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace ManageTickets.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly ApplicationDbContext _context;

        public TicketRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetTicketsAsync(int pageNumber, int pageSize)
        {
            return await _context.Tickets
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Ticket> CreateTicketAsync(Ticket ticket)
        {
            ticket.Date = DateTime.Now;
           
           
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<Ticket?> UpdateTicketAsync(long id, Ticket ticket)
        {
            var existingTicket = await _context.Tickets.FindAsync(id);
            if (existingTicket == null)
                return null;

            existingTicket.Description = ticket.Description;
            existingTicket.Status = ticket.Status;
            _context.Entry(existingTicket).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return existingTicket;
        }

        public async Task<bool> DeleteTicketAsync(long id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
                return false;

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
