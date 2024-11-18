using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

public class CacheService
{
    private readonly IDistributedCache _redis;

    public CacheService(IDistributedCache cache)
    {
        _redis = cache;
    }

    /// <summary>
    /// Função para buscar dados da memoria cache ou de outra fonte. Caso não exista no cache, os dados são buscados de outra fonte e salvos no cache.
    /// </summary>
    /// <typeparam name="T">Tipo de dado à ser retornado. Normalmente um model, entity ou DTO</typeparam>
    /// <param name="cacheKey">Chave à ser salva no redis</param>
    /// <param name="absoluteExpiration">Tempo de expiração máximo dos dados inseridos na cache</param>
    /// <param name="slidingExpiration">O dado na memoria cache só será expirado se não for acessado dentro do periodo atribuido, caos contrário, renovará o tempo de expiração</param>
    /// <returns>Retorna um tipo de dado escolhido, geralmente um model, entity ou DTO</returns>
    public async Task<T?> GetCacheAsync<T>(string cacheKey)
    {
        // Verificar se já existe no cache
        string? cachedData = await _redis.GetStringAsync(cacheKey);
        if (cachedData != null)
        {
            return JsonSerializer.Deserialize<T>(cachedData);
        }

        return default;
    }

    /// <summary>
    /// Insere ou atualiza o valor da memoria cache
    /// </summary>
    /// <typeparam name="T">Tipo do parâmetro</typeparam>
    /// <param name="cacheKey">Chave do item da memoria cache</param>
    /// <param name="cacheValue">Valor do item da memoria cache</param>
    /// <returns></returns>
    public async Task SetCacheAsync<T>(string cacheKey, T cacheValue)
    {
        string serializedValue = JsonSerializer.Serialize(cacheValue);

        // Insere/Atualiza o cache
        await _redis.SetStringAsync(cacheKey, serializedValue, new DistributedCacheEntryOptions { 
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5),
            SlidingExpiration = TimeSpan.FromMinutes(2)
        });

    }

    /// <summary>
    /// Função para remover Keys de cache inválidas ou desatualizadas
    /// </summary>
    /// <param name="key">Chave à ser removida</param>
    /// <returns></returns>
    public async Task InvalidateCache(string key)
    {
        await _redis.RemoveAsync(key);
    }
}
