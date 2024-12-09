using System.ComponentModel.DataAnnotations;

namespace Common.DTOs;

public class LoginRequestDTO
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
}