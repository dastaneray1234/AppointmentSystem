using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AppointmentSystem.Data.Entities;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}