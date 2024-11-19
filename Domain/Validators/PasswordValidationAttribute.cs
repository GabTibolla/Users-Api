using System.ComponentModel.DataAnnotations;

namespace API.Domain.Validators
{
    public class PasswordValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value == null)
                return false;

            var password = value.ToString();

            // Verifica os critérios de validação
            bool hasUpperCase = password!.Any(char.IsUpper); // Pelo menos 1 letra maiúscula
            bool hasLowerCase = password!.Any(char.IsLower); // Pelo menos 1 letra minúscula
            bool hasDigit = password!.Any(char.IsDigit);     // Pelo menos 1 número
            bool hasSpecialChar = password!.Any(c => "!@#$%^&*()_+-".Contains(c)); // Pelo menos 1 caractere especial
            bool isCorrectLength = password!.Length >= 8 && password!.Length <= 30;

            // Retorna verdadeiro apenas se todos os critérios forem atendidos
            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar && isCorrectLength;
        }
    }
}
