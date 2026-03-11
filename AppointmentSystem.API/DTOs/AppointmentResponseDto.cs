namespace AppointmentSystem.API.DTOs;

public class AppointmentResponseDto
{
    public int Id { get; set; }
    public string? AppUserId { get; set; }
    public int ServiceId { get; set; }
    public DateTime AppointmentDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public string Status { get; set; } = string.Empty;
}
