namespace ExpenseTrackerAPI.DTOs
{
    public class UpdateExpenseDto
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryId { get; set; }
    }
}
