namespace AppointmentSystem.Data.Entities;

public class Appointment
{
    public int Id { get; set; }

    public string? AppUserId { get; set; }
    public AppUser? AppUser { get; set; }

    public int ServiceId { get; set; }
    public Service Service { get; set; } = null!;

    public DateTime AppointmentDate { get; set; }

    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }

    public string Status { get; set; } = "Pending";
}