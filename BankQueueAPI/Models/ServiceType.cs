namespace BankQueueAPI.Models
{
    public class ServiceType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Prefix { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
