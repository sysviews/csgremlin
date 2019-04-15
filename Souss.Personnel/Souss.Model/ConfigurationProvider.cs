using Microsoft.Extensions.Configuration;

namespace Souss.Model
{
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfiguration _configuration;

        public ConfigurationProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string ConnectionEndpoint => _configuration["Connection:Endpoint"];

        public int Port => int.TryParse(_configuration["Connection:Port"], out var result) ? result : 443;

        public string ConnectionDatabaseCollection => _configuration["Connection:DatabaseCollection"];

        public string ConnectionAuthKey => _configuration["Connection:AuthKey"];
    }
}
