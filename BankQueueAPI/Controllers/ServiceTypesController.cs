using BankQueueAPI.Data;
using BankQueueAPI.DTOs;
using BankQueueAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace BankQueueAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypesController : ControllerBase
    {
        private readonly AppDbcontext _context;

        public ServiceTypesController(AppDbcontext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> AllServices()
        {
            var services = await _context.ServiceTypes.ToListAsync();

            return Ok(services);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(CreateServiceDto dto)
        {
            var serviceType = new ServiceType()
            {
                Name = dto.Name,
                Prefix = dto.Prefix,
            };

            await _context.ServiceTypes.AddAsync(serviceType);
            await _context.SaveChangesAsync();  

            return Ok("Created Successfully");
        }

    }
}
