namespace ExpenseTrackerAPI.DTOs
{
    public class GetExpensesDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string CategoryName { get; set; }
    }
}
