using API.Domain.Enums;
using API.Domain.Validators;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
namespace API.Domain.Entities;

[Table("users")]
[Index(nameof(Email), IsUnique = true)]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(140)]
    [EmailAddress(ErrorMessage = "Este e-mail já está cadastrado")]
    public string? Email { get; set; }

    [JsonIgnore]
    [Required]
    public string? Password { get; set; }

    [Required]
    public UserPermissionEnum Permissions { get; set; }
}
