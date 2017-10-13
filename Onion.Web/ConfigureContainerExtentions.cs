using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onion.Repo;
using Onion.Repo.Data;
using Onion.Repo.Identity;
using Onion.Service;
using Onion.Service.Interfaces;

namespace Onion.Web
{
    public static class ConfigureContainerExtensions
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
            string dataConnectionString = null, string authConnectionString = null)
        {
            serviceCollection.AddDbContext<DataContext>(options =>
                options.UseSqlite(dataConnectionString ?? GetDataConnectionStringFromConfig()));

            serviceCollection.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite(authConnectionString ?? GetAuthConnectionFromConfig()));

            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }
        
        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(DataRepository<>));
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBookService, BookService>();

            serviceCollection.AddTransient<IEmailSender, EmailSender>();
        }
        
        private static string GetDataConnectionStringFromConfig()
        {
            return new DatabaseConfiguration().GetDataConnectionString();
        }

        private static string GetAuthConnectionFromConfig()
        {
            return new DatabaseConfiguration().GetAuthConnectionString();
        }
    }
}