namespace AppointmentSystem.API.DTOs;

public class CreateServiceDto
{
    public string Name { get; set; } = string.Empty;
    public int DurationInMinutes { get; set; }
    public decimal Price { get; set; }
    public bool IsActive { get; set; } = true;
}