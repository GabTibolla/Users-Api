using API.Domain.Entities;

namespace API.Domain.Interfaces
{
    public interface IUser
    {
        Task<UserEntity> AddUserSync(UserEntity userEntity);
        Task<IEnumerable<UserEntity>> GetUsers();
        Task<UserEntity?> GetUserByEmail(string email);
        Task<UserEntity> UpdateUser(UserEntity userEntity);
        Task<bool> DeleteUser(UserEntity userEntity);
    }
}
