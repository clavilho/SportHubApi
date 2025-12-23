using MongoDB.Driver;
using SportHubApi.Domain.Adapters;
using SportHubApi.Domain.Entities;
using System.Text.RegularExpressions;

namespace SportHubApi.DbRepository
{
    public class DbRepositoryAdapter : IDbRepositoryAdapter
    {
        private readonly IMongoCollection<User> _users;
        //private readonly IMongoCollection<Team> _teams;
        //private readonly IMongoCollection<Match> _matches;

        public DbRepositoryAdapter(IMongoDatabase database)
        {
            _users = database.GetCollection<User>("User");
            //_teams = database.GetCollection<Team>("Team");
            //_matches = database.GetCollection<Match>("Match");
        }

        public async Task InsertUserAsync(User user)
          => await _users.InsertOneAsync(user);
    }
}
