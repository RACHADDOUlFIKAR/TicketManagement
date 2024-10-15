using ManageTickets.Models.Enums;

namespace ManageTickets.Models.Entities
{
    public class Ticket
    {
        public long TicketId { get; set; } 
        public string? Description { get; set; } 
        public Status Status { get; set; }
        public DateTime Date { get; set; } 
        public string? StatusString => Status.ToString();
    }

}
