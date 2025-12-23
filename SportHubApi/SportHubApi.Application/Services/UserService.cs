using SportHubApi.Domain.Adapters;
using SportHubApi.Domain.Entities;
using SportHubApi.Domain.Services;

namespace SportHubApi.Application.Services;

public class UserService : IUserService
{
    private readonly IDbRepositoryAdapter _dbRepositoryAdapter;
    public UserService(IDbRepositoryAdapter _dbRepositoryAdapter)
    {
        this._dbRepositoryAdapter = _dbRepositoryAdapter;
    }

    public async Task CreateAsync(User user)
    {
        await _dbRepositoryAdapter.InsertUserAsync(user);
    }
}
