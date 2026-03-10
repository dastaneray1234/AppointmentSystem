using AppointmentSystem.Data.Context;
using AppointmentSystem.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentSystem.API.DTOs;

namespace AppointmentSystem.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ServiceController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var services = await _context.Services.ToListAsync();
        return Ok(services);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
            return NotFound();
        return Ok(service);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceDto dto)
    {
        var service = new Service
        {
            Name = dto.Name,
            DurationInMinutes = dto.DurationInMinutes,
            Price = dto.Price,
            IsActive = dto.IsActive
        };

        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = service.Id }, service);
    }


}