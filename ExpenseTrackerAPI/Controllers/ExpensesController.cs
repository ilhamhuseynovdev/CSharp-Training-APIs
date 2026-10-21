using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.DTOs;
using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ExpensesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllExpenses")]
        public async Task<IActionResult> GetExpenses()
        {
            List<GetExpensesDto> expenses = await _context.Expenses
                .Include(e => e.Category)
                .Select(e => new GetExpensesDto()
                {
                    Id = e.Id,
                    Amount = e.Amount,
                    Title = e.Title,
                    Date = e.Date,
                    CategoryName = e.Category.Name,
                })
                .ToListAsync();
            return Ok(expenses);
        }

        [HttpPost("CreateExpense")]
        public async Task<IActionResult> CreateExpense(CreateExpenseDto dto)
        {
            var expense = new Expense();

            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);
            if (!categoryExists) return NotFound("Category not found");


            expense.Amount = dto.Amount;
            expense.Title = dto.Title;
            expense.Date = dto.Date;
            expense.CategoryId = dto.CategoryId;
            
            await _context.Expenses.AddAsync(expense);
            await _context.SaveChangesAsync();

            return Ok("Created");
        }

        [HttpPost("UpdateExpense-{Id}")]
        public async Task<IActionResult> UpdateExpense(int Id,UpdateExpenseDto dto)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e=>e.Id == Id);
            if (expense == null) return NotFound("Wrong Id please try again");

            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == dto.CategoryId);
            if (!categoryExists) return NotFound("Category not found");

            expense.Amount = dto.Amount;
            expense.Title = dto.Title;
            expense.Date = dto.Date;
            expense.CategoryId= dto.CategoryId;

            await _context.SaveChangesAsync();

            return Ok("Updated");
        }

        [HttpDelete("DeleteExpense-{Id}")]
        public IActionResult DeleteExpense(int Id)
        {
            var expense = _context.Expenses.FirstOrDefault(c => c.Id == Id);
            if (expense is null) return NotFound("Wrong ID please try again");

            _context.Expenses.Remove(expense);
            _context.SaveChanges();

            return Ok("Deleted permanently..");
        }
    }

}
