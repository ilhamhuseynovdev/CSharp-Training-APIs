using BankQueueAPI.Utilities.Enums;

namespace BankQueueAPI.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int TicketNumber { get; set; }
        public DateTime IssueTime { get; set; }
        public TicketStatus Status { get; set; }
        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }
    }
}
