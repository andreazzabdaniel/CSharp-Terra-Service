using System.ComponentModel.DataAnnotations;
using terraservice.Domain.Enums;

namespace terraservice.Domain.Entities;

public class User
{
    public Guid UserId { get; set; } = new Guid();
    public string Name { get; set; } = String.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = String.Empty;
    public string Role { get; set; } = UserRole.TEAM_MEMBER;
}