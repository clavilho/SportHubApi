using SportHubApi.Domain.Entities;

namespace SportHubApi.Domain.Services;

public interface IUserService
{
    /// <summary>
    /// Utilizado para cadastrar usuario no banco
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task CreateAsync(User user);
}
