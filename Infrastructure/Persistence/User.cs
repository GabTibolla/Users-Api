using API.Domain.Entities;
using API.Domain.Interfaces;
using API.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Persistence;

public class User : IUser
{
    private readonly AppDbContext _context;
    private readonly CacheService _cacheService;

    public User(AppDbContext context, CacheService cacheService)
    {
        _context = context;
        _cacheService = cacheService;
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

    public async Task<UserEntity?> GetUserByEmail(string email)
    {
        // Configurando a chave do cache
        string cacheKey = $"usuario:email:{email}";

        // Usando o serviço de cache para buscar na cache
        var user = await _cacheService.GetCacheAsync<UserEntity?>(cacheKey);

        if (user != null)
        {
            return user;
        }


        user = await _context.Set<UserEntity>().FirstOrDefaultAsync(x => x.Email == email);
        if (user != null)
        {
            // Atualiza na memoria cache
            await _cacheService.SetCacheAsync(cacheKey, user);
        }

        return user;
    }

    public async Task<UserEntity> UpdateUser(UserEntity userEntity)
    {
        // Configurando a chave do cache
        string cacheKey = $"usuario:email:{userEntity.Email}";

        // Usando o serviço de cache para remover a chave do cache
        await _cacheService.InvalidateCache(cacheKey);

        // Atualiza a memoria cache
        await _cacheService.SetCacheAsync(cacheKey, userEntity);

        _context.Set<UserEntity>().Attach(userEntity);
        _context.Entry(userEntity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return userEntity;
    }

    public async Task<bool> DeleteUser(UserEntity userEntity)
    {
        // Configurando a chave do cache
        string cacheKey = $"usuario:email:{userEntity.Email}";

        // Usando o serviço de cache para remover a chave do cache
        await _cacheService.InvalidateCache(cacheKey);

        _context.Set<UserEntity>().Attach(userEntity);
        _context.Entry(userEntity).State = EntityState.Deleted;
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
