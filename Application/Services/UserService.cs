using API.Application.DTOs;
using API.Domain.Entities;
using API.Domain.Interfaces;

namespace API.Application.Services;

public class UserService
{
    private readonly IUser _user;

    public UserService(IUser IUser)
    {
        _user = IUser;
    }

    public async Task<UserEntity> CreateUserAsync(UserDTO userDTO)
    {
        var userEntity = new UserEntity
        {
            Id = Guid.NewGuid(),
            Name = userDTO.Name,
            Email = userDTO.Email,
            Password = userDTO.Password,
            Permissions = userDTO.Permissions
        };

        return await _user.AddUserSync(userEntity);
    }

    public async Task<IEnumerable<UserEntity>> GetUsersAsync()
    {
        return await _user.GetUsers();
    }

    public async Task<UserEntity?> GetUserByEmail(String email) {
        return await _user.GetUserByEmail(email);
    }

    public async Task<UserEntity?> UpdateUser(String email, UserDTO userDTO)
    {
        // Busca o usuário com base no email e na senha informada
        var userEntity = await _user.GetUserByEmail(email);

        if (userEntity == null) {
            return null;
        }

        // Atualiza as informações do usuário
        userEntity.Name = userDTO.Name;
        userEntity.Email = userDTO.Email;
        userEntity.Password = userDTO.Password;
        userEntity.Permissions = userDTO.Permissions;

        await _user.UpdateUser(userEntity);
        return userEntity;
    }

    public async Task<bool?> DeleteUser(String email) {
        var userEntity = await _user.GetUserByEmail(email);
        if (userEntity == null)
        {
            return null;
        }

        return await _user.DeleteUser(userEntity);
    }
}
