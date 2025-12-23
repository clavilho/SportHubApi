using SportHubApi.Domain.Entities;

namespace SportHubApi.Domain.Adapters
{
    public interface IDbRepositoryAdapter
    {
        /// <summary>
        /// Usado para inserir usuario no banco
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task InsertUserAsync(User user);
    }
}
