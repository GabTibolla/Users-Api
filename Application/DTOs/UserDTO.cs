using API.Domain.Enums;
using API.Domain.Validators;
using System.ComponentModel.DataAnnotations;

namespace API.Application.DTOs
{
    public class UserDTO
    {
        [Required]
        [MaxLength(80)]
        public string? Name { get; set; }

        [Required]
        [MaxLength(140)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(30)]
        [PasswordValidationAttribute(ErrorMessage = "A senha precisa atender à todos os requisitos")]
        public string? Password { get; set; }

        [Required]
        [EnumDataType(typeof(UserPermissionEnum))]
        [PermissionValidation(ErrorMessage = "Permissão inválida.")]
        public UserPermissionEnum Permissions { get; set; }
    }
}
