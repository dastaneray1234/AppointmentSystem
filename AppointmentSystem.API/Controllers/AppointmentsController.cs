namespace AppointmentSystem.API.Controllers;

using AppointmentSystem.API.DTOs;
using AppointmentSystem.Data.Context;
using AppointmentSystem.Data.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class AppointmentsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AppointmentsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAppointmentDto dto)
    {
        var service = await _context.Services.FindAsync(dto.ServiceId);

        if (service is null)
            return NotFound("Service not found.");

        var appointment = _mapper.Map<Appointment>(dto);
        appointment.EndTime = dto.StartTime.Add(TimeSpan.FromMinutes(service.DurationInMinutes));

        await _context.Appointments.AddAsync(appointment);
        await _context.SaveChangesAsync();

        var response = _mapper.Map<AppointmentResponseDto>(appointment);
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var appointments = await _context.Appointments.ToListAsync();
        var response = _mapper.Map<List<AppointmentResponseDto>>(appointments);

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment is null)
            return NotFound("Appointment not found.");

        var response = _mapper.Map<AppointmentResponseDto>(appointment);
        return Ok(response);
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Update(int id, CreateAppointmentDto dto)
    {
        var appointment = await _context.Appointments.FindAsync(id);

        if (appointment is null)
            return NotFound("Appointment not found.");

        var service = await _context.Services.FindAsync(dto.ServiceId);

        if (service is null)
            return NotFound("Service not found.");

        appointment.AppUserId = dto.AppUserId;
        appointment.ServiceId = dto.ServiceId;
        appointment.AppointmentDate = dto.AppointmentDate;
        appointment.StartTime = dto.StartTime;
        appointment.EndTime = dto.StartTime.Add(TimeSpan.FromMinutes(service.DurationInMinutes));
        appointment.Status = dto.Status;

        await _context.SaveChangesAsync();

        var response = _mapper.Map<AppointmentResponseDto>(appointment);
        return Ok(response);
    }

    

    
}
