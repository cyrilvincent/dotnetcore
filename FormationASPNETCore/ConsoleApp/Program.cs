// See https://aka.ms/new-console-template for more information
using FormationASPNETCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

Console.WriteLine("Hello, World!");
var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkNpgsql()
                .BuildServiceProvider();
var builder = new DbContextOptionsBuilder<FormationDbContext>();
builder.UseNpgsql<FormationDbContext>("Host=localhost;Port=5433;Database=mydb;Username=postgres;Password=mot-de-passe")
    .UseInternalServiceProvider(serviceProvider);
var context = new FormationDbContext(builder.Options);
var publishers = context.Publishers.ToList();
foreach (var publisher in publishers)
{
    Console.WriteLine(publisher.Name);
}
Console.ReadLine();

