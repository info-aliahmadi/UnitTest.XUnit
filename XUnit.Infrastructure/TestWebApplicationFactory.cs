
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using XUnit.Service.Data.Infra;
using XUnit.Service.Service;

namespace XUnit.Infrastructure
{
    public class ApiWebApplicationFactory : WebApplicationFactory<Program>
    {
        public IConfiguration Configuration { get; private set; }
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(config =>
            {
                Configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .Build();
                config.AddConfiguration(Configuration);
            });
            builder.ConfigureTestServices(services =>
            {
                services.AddTransient<IQueryRepository, QueryRepository>();
                services.AddTransient<ICommandRepository, CommandRepository>();
                services.AddTransient<IAuthorService, AuthorService>();
                services.AddTransient<IRoleService, RoleService>();

                /* If you are using Identity and Authorize attribute on controller or actions, uncomment code below: */

                //services.AddAuthentication(defaultScheme: "TestScheme")
                // .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>(
                //     "TestScheme", options => { });

            });

        }
    }
}