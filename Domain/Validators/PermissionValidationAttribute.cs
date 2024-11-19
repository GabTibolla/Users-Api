using API.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.Domain.Validators;


public class PermissionValidationAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value == null)
            return false;

        var permission = (UserPermissionEnum)value;

        // Validação customizada: Permite apenas Admin ou User
        if (permission == UserPermissionEnum.Admin || permission == UserPermissionEnum.User || permission == UserPermissionEnum.Guest)
        {
            return true;
        }

        return false;
    }
}

