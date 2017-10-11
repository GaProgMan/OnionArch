using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Onion.Repo.Data;
using Onion.Repo.Extensions;

namespace Onion.Web.Extensions
{
    /// <summary>
    /// This class is based on some of the suggestions bty K. Scott Allen in
    /// his NDC 2017 talk https://www.youtube.com/watch?v=6Fi5dRVxOvc
    /// </summary>
    public static class ConfigureHttpPipelineExtentions
    {
        private static string CorsPolicyName => new CorsConfiguration().GetCorsPolicyName();
        
        public static void UseCustomisedMvc(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public static void UseCorsPolicy(this IApplicationBuilder applicationBuilder, string corsPolicyName = null)
        {
            applicationBuilder.UseCors(corsPolicyName ?? CorsPolicyName);
        }

        public static int EnsureDatabaseIsSeeded(this IApplicationBuilder applicationBuilder,
            bool autoMigrateDatabase)
        {
            // seed the database using an extension method
            using (var serviceScope = applicationBuilder.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                .CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<DwContext>();
                if (autoMigrateDatabase)
                {
                    context.Database.Migrate();
                }
                return context.EnsureSeedData();
            }
        }
    }
}