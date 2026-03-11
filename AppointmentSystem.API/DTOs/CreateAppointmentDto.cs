namespace AppointmentSystem.API.DTOs;


public class CreateAppointmentDto
{
    public string? AppUserId { get; set; }
    public int ServiceId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public string Status { get; set; } = "Pending";
}