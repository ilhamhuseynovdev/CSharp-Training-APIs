using ExpenseTrackerAPI.Data;
using ExpenseTrackerAPI.DTOs;
using ExpenseTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllCategories")]
        public async Task<IActionResult> GetCategories()
        {
            List<GetCategoriesDto> dto = await _context.Categories
                .Select(x=> new GetCategoriesDto
                {
                    Id= x.Id,
                    Name = x.Name,
                })
                .ToListAsync();

            return Ok(dto);
        }


        [HttpPost("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto dto)
        {
            var newCategory = new Category();

            var isExistsName = await _context.Categories.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower());
            if (isExistsName) return BadRequest("Name already exists");

            newCategory.Name = dto.Name;

            await _context.Categories.AddAsync(newCategory);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("UpdateCategory-{Id}")]
        public async Task<IActionResult> UpdateCategory(int Id,UpdateCategoryDto dto)
        {
            var oldCategory = await _context.Categories.FirstOrDefaultAsync(c=>c.Id == Id);
            if (oldCategory is null) return NotFound("Wrong ID please try again");

            var isExistsName = await _context.Categories.AnyAsync(x => x.Name.ToLower() == dto.Name.ToLower() && x.Id != Id);
            if (isExistsName) return BadRequest("Name already exists");

            oldCategory.Name = dto.Name;

            await _context.SaveChangesAsync();

            return Ok("UPDATED...");
        }

        [HttpDelete("DeleteCategory-{Id}")]
        public IActionResult DeleteCategory(int Id)
        {
            var category = _context.Categories.FirstOrDefault(c=>c.Id == Id);
            if (category is null) return NotFound("Wrong ID please try again");

            _context.Categories.Remove(category);
             _context.SaveChanges();

            return Ok("Deleted permanently..");
        }
    }
}
