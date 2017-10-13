using Microsoft.Extensions.Configuration;

namespace Onion.Repo
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private string DataConnectionKey = "onionDataConnection";

        private string AuthConnectionKey = "onionAuthConnection";

        public string GetDataConnectionString()
        {
            return GetConfiguration().GetConnectionString(DataConnectionKey);
        }
        
        public string GetAuthConnectionString()
        {
            return GetConfiguration().GetConnectionString(AuthConnectionKey);
        }
    }
}