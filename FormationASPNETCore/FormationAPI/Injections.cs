using FormationAPI.Services;
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

        public static void InjectGestionCompteService(IServiceCollection services)
        {
            services.AddScoped<IGestionCompteService, GestionCompteService>();
        }

        public static void InjectGestionUseService(IServiceCollection services)
        {
            services.AddScoped<ICompteUseService, CompteUseService>();
        }

        public static void InjectBankService(IServiceCollection services)
        {
            services.AddScoped<IBankService, BankService>();
        }
    }
}
