using Onion.Repo;

namespace Onion.Web
{
    public class CorsConfiguration : ConfigurationBase
    {
        private string CorsPolicyKey = "CorsPolicy:name";
        public string GetCorsPolicyName()
        {
            var section = GetConfiguration().GetSection(CorsPolicyKey);
            if (section == null)
            {
                RaiseValueNotFoundException(CorsPolicyKey);
            }
            return section.Value;
        }
    }
}