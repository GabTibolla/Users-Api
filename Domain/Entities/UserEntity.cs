using API.Domain.Enums;
using API.Domain.Validators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace API.Domain.Entities;

[Table("users")]
public class UserEntity
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(80)]
    public string? Name { get; set; }

    [Required]
    [MaxLength(140)]
    public string? Email { get; set; }

    [JsonIgnore]
    public string? Password { get; set; }

    [Required]
    public UserPermissionEnum Permissions { get; set; }
}
