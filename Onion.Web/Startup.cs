using ClacksMiddleware.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Onion.Web.Extensions;
using OwaspHeaders.Core.Extensions;
using OwaspHeaders.Core.Models;

namespace Onion.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.AddSecureHeadersMiddlewareConfiguration(
                Configuration.GetSection("SecureHeadersMiddlewareConfiguration"));
            services.AddCustomizedMvc();
            services.AddCorsPolicy();
            services.AddDbContext();
            services.AddRepository();
            services.AddTransientServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IOptions<SecureHeadersMiddlewareConfiguration> secureHeaderSettings)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.EnsureDatabaseIsSeeded(false);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.GnuTerryPratchett();
            app.UseSecureHeadersMiddleware(secureHeaderSettings.Value);

            app.UseStaticFiles();
            app.UseCorsPolicy();

            app.UseAuthentication();

            app.UseCustomisedMvc();
        }
    }
}

