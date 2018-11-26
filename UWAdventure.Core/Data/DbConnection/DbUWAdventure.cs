using Microsoft.Extensions.Configuration;

namespace UWAdventure.Data
{
    /// <summary>
    /// Provides connection string information for UWAdventure
    /// </summary>
    public class DbUWAdventure : IDbUWAdventure
    {
        private readonly IConfiguration _config;
        public DbUWAdventure(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Returns the connection string
        /// </summary>
        /// <param name="name">Connection string key</param>
        /// <returns></returns>
        public string GetConnectionString(string name)
        {
            return _config.GetConnectionString(name);
        }
    }
}
