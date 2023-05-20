using Microsoft.IdentityModel.Tokens;
using System.Text.Json.Serialization;

namespace TrainingsAppApi.Configuration
{
    public interface IDbConfiguration
    {
        string WebApiDatabaseConnectionString { get; }
    }

    public class DbConfiguration : IDbConfiguration
    {
        private readonly IConfiguration _configuration;

        public DbConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string WebApiDatabaseConnectionString => _configuration.GetConnectionString("MySqlDb");
    }
}
