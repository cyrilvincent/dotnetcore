using FormationASPNETCore.Entities;
using FormationASPNETCore.Extensions;

namespace FormationASPNETCore.Services
{
    public interface IPublisherService
    {
        IQueryable<Publisher> FilterByName(string name);
        Publisher Mock();
    }
    public class PublisherService : AEntityService<Publisher>, IPublisherService
    {
        public PublisherService(
            FormationDbContext dbContext,
            ILogger<PublisherService> logger
        ) : base(dbContext, logger)
        {
        }

        public IQueryable<Publisher> FilterByName(string name)
        {
            return dbContext.Publishers.FilterByName(name);
        }

        public Publisher Mock()
        {
            return new Publisher { Id = 1, Name = "Cyril" };
        }
    }
}
