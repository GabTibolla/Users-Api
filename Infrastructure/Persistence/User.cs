using API.Domain.Entities;
using API.Domain.Interfaces;
using API.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Persistence;

public class User : IUser
{
    private readonly AppDbContext _context;

    public User(AppDbContext context)
    {
        _context = context;
    }

    public async Task<UserEntity> AddUserSync(UserEntity userEntity)
    {
        await _context.Set<UserEntity>().AddAsync(userEntity);
        await _context.SaveChangesAsync();
        return userEntity;
    }

    public async Task<IEnumerable<UserEntity>> GetUsers()
    {
        return await _context.Set<UserEntity>().ToListAsync();
    }

    public async Task<UserEntity?> GetUserByEmail(string email) { 
       var userEntity = await _context.Set<UserEntity>().FirstOrDefaultAsync(x=> x.Email == email);
        return userEntity;
    }

    public async Task<UserEntity> UpdateUser(UserEntity userEntity)
    {
        _context.Set<UserEntity>().Attach(userEntity);
        _context.Entry(userEntity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return userEntity;
    }

    public async Task<bool> DeleteUser(UserEntity userEntity) {
        _context.Set<UserEntity>().Attach(userEntity);
        _context.Entry(userEntity).State = EntityState.Deleted;
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
