using ManageTickets.Models.Entities;

namespace ManageTickets.IRepositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetTicketsAsync(int pageNumber, int pageSize);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task<Ticket?> UpdateTicketAsync(long id, Ticket ticket);
        Task<bool> DeleteTicketAsync(long id);
    }
}
