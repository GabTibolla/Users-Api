using System.ComponentModel.DataAnnotations;

namespace API.Domain.Validators
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            var password = value.ToString();

            // Validação customizada: Deve conter pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número e 1 caractere especial
            if (password.Length >= 8 && password.Length <= 30 &&
                password.Contains("ABCDEFGHIJKLMNOPQRSTUVWXYZ") &&
                password.Contains("abcdefghijklmnopqrstuvwxyz") &&
                password.Contains("0123456789") &&
                password.Contains("!@#$%^&*()_+"))
            {
                return true;
            }

            return false;
        }
    }
}
