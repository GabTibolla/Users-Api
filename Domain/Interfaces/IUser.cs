using API.Domain.Entities;

namespace API.Domain.Interfaces
{
    public interface IUser
    {
        /// <summary>
        /// Adiciona um novo usuário
        /// </summary>
        /// <param name="userEntity">Usuário à ser inserido</param>
        /// <returns>Retorna o usuário inserido</returns>
        Task<UserEntity> AddUserSync(UserEntity userEntity);

        /// <summary>
        /// Busca todos os usuários do banco de dados
        /// </summary>
        /// <returns>Retorna uma lista com todos os usuários</returns>
        Task<IEnumerable<UserEntity>> GetUsers();

        /// <summary>
        /// Busca um usuário pelo email
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <returns>Retorna o usuário pelo e-mail</returns>
        Task<UserEntity?> GetUserByEmail(string email);

        /// <summary>
        /// Atualiza um usuário existente
        /// </summary>
        /// <param name="userEntity">Usuário à ser atualizado</param>
        /// <returns>Retorna o usuário atualizado</returns>
        Task<UserEntity> UpdateUser(UserEntity userEntity);

        /// <summary>
        /// Deleta um usuário
        /// </summary>
        /// <param name="userEntity">Usuário à ser deletado</param>
        /// <returns>Retorna se conseguiu ou não deletar</returns>
        Task<bool> DeleteUser(UserEntity userEntity);
    }
}
