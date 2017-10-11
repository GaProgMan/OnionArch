using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Onion.Repo;
using Onion.Repo.Data;
using Onion.Repo.Identity;
using Onion.Repo.Interfaces;
using Onion.Service;
using Onion.Service.Interfaces;
using OwaspHeaders.Core.Models;

namespace Onion.Web.Extensions
{
    /// <summary>
    /// This class is based on some of the suggestions bty K. Scott Allen in
    /// his NDC 2017 talk https://www.youtube.com/watch?v=6Fi5dRVxOvc
    /// </summary>
    public static class ConfigureContainerExtenstions
    {
        private static string CorsPolicyName => new CorsConfiguration().GetCorsPolicyName();

        public static void AddDbContext(this IServiceCollection serviceCollection,
            string dataConnectionString = null, string authConnectionString = null)
        {
            serviceCollection.AddDbContext<DwContext>(options =>
                options.UseSqlite(dataConnectionString ?? GetDataConnectionStringFromConfig()));

            serviceCollection.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite(authConnectionString ?? GetAuthConnectionFromConfig()));

            serviceCollection.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>();
        }

        public static void AddRepository(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IRepository<>), typeof(DwRepository<>));
        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IBookService, BookService>();
            serviceCollection.AddTransient<IBookSeriesService, BookSeriesService>();
            serviceCollection.AddTransient<ISeriesService, SeriesService>();

            serviceCollection.AddTransient<IEmailSender, EmailSender>();
        }

        public static void AddCustomizedMvc(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddMvc();
        }

        public static void AddCorsPolicy(this IServiceCollection serviceCollection, string corsPolicyName = null)
        {
            serviceCollection.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName ?? CorsPolicyName,
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        public static void AddSecureHeadersMiddlewareConfiguration(this IServiceCollection serviceCollection,
            IConfigurationSection configSection)
        {
            serviceCollection.Configure<SecureHeadersMiddlewareConfiguration>(configSection);
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