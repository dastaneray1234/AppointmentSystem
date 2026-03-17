using AppointmentSystem.Data.Context;
using AppointmentSystem.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AppointmentSystem.API.DTOs;
using AutoMapper;

namespace AppointmentSystem.API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly ApplicationDbContext _context;
 private readonly IMapper _mapper;
    public ServiceController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var services = await _context.Services.ToListAsync();
        var response =  _mapper.Map<List<ServiceResponseDto>>(services);
        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
            return NotFound();

        var response = _mapper.Map<ServiceResponseDto>(service);    
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateServiceDto dto)
    {
       var service = _mapper.Map<Service>(dto);
        await _context.Services.AddAsync(service);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<ServiceResponseDto>(service);

        return CreatedAtAction(nameof(GetById), new { id = service.Id }, response);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, CreateServiceDto dto)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null)
            return NotFound();

     var serviceEntity = _mapper.Map(dto, service);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<ServiceResponseDto>(serviceEntity);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var service = await _context.Services.FindAsync(id);

        if (service == null)
            return NotFound();

        var hasAppointments = await _context.Appointments.AnyAsync(a => a.ServiceId == id);
        if (hasAppointments)
        {
            service.IsActive = false;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return NoContent();
    }


}