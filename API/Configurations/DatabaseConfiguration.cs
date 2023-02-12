using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ChallengeTecnicoEngee.API.Configurations
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDatabaseModule(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("AppConnectionString");
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connection));

            return services;
        }

        public static IApplicationBuilder UseDatabaseMigration(this IApplicationBuilder app, IServiceProvider serviceProvider, IHostEnvironment environment)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                if (environment.EnvironmentName == "Development")
                {
                    context.Database.Migrate();
                }
            }

            return app;
        }
    }
}
