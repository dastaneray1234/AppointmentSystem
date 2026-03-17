using System.ComponentModel.DataAnnotations;

namespace AppointmentSystem.API.DTOs;

public class CreateServiceDto
{
    [Required]
    [MinLength(2)]
    public string Name { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int DurationInMinutes { get; set; }

    [Range(typeof(decimal), "0", "79228162514264337593543950335")]
    public decimal Price { get; set; }

    public bool IsActive { get; set; } = true;
}
