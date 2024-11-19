using Microsoft.AspNetCore.Identity;

public class PasswordService
{
    private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

    /// <summary>
    /// Função para criptografar a senha
    /// </summary>
    /// <param name="password">Informe o dado a ser criptografado</param>
    /// <returns>String criptografada</returns>
    public string HashPassword(string password)
    {
        return _passwordHasher.HashPassword(null, password);
    }

    /// <summary>
    /// Função para comparar a senha inserida com a senha criptografada
    /// </summary>
    /// <param name="hashedPassword">Senha criptografada</param>
    /// <param name="password">Senha à ser comparada</param>
    /// <returns>Booleano resultado da comparação</returns>
    public bool VerifyPassword(string hashedPassword, string password)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}
