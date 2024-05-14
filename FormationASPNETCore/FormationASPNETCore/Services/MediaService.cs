using FormationASPNETCore.Adapters;
using FormationASPNETCore.Dtos;
using FormationASPNETCore.Entities;
using FormationASPNETCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FormationASPNETCore.Services
{
    public interface IMediaService
    {
        IQueryable<Publisher> GetPublishersByName(string name);
        IQueryable<MediaDTO> FilterByTitle(string title);
        Publisher Mock();
    }
    public class MediaService : AEntityService<Media>, IMediaService
    {

        public MediaService(
            FormationDbContext dbContext,
            ILogger<MediaService> logger
        ) : base(dbContext, logger)
        {
            logger.LogCritical("Injection ok");
        }

        public IQueryable<Publisher> GetPublishersByName(string name)
        {
            return dbContext.Publishers.FilterByName(name);
        }

        public IQueryable<MediaDTO> FilterByTitle(string title)
        {
            return dbContext.Medias.Include(e => e.Publisher).FilterByTitle(title).Select(e => e.ToMediaDTO());
        }


        public Publisher Mock()
        {
            logger.LogInformation("Mock");
            return new Publisher { Id = 1, Name = "Cyril" };
        }
    }
}
