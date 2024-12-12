using Microsoft.EntityFrameworkCore;

namespace FormationAPI
{
    public static class Injections
    {
        public static void InjectDbContext(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<FormationDbContext>(options =>
            {
                options.UseSqlServer(connectionString)
                       .LogTo(Console.WriteLine);
            });
        }
    }
}
