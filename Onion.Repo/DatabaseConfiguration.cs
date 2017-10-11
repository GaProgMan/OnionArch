using Microsoft.Extensions.Configuration;

namespace Onion.Repo
{
    public class DatabaseConfiguration : ConfigurationBase
    {
        private string DataDbConnectionKey = "onionDataConnection";
        private string AuthDbConnectionKey = "onionAuthConnection";
        
        public string GetDataConnectionString()
        {
            return GetConfiguration().GetConnectionString(DataDbConnectionKey);
        }

        public string GetAuthConnectionString()
        {
            return GetConfiguration().GetConnectionString(AuthDbConnectionKey);
        }
    }
}