using FormationASPNETCore.Services;
using Microsoft.EntityFrameworkCore;

namespace FormationASPNETCore
{
    public static class Injections
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IMediaService, MediaService>();
        }

        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FormationDbContext>(options =>
            {
                options.UseNpgsql(connectionString)
                       .LogTo(Console.WriteLine);
            });
        }
    }
}
