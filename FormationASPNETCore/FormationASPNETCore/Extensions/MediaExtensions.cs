using FormationASPNETCore.Entities;

namespace FormationASPNETCore.Extensions
{

    public static class MediaExtensions
    {

        public static IQueryable<Media> FilterByMediaType(this IQueryable<Media> entities, MediaType type)
        {
            return entities.Where(m => m.MediaType == type);
        }

        public static IQueryable<Media> FilterByTitle(this IQueryable<Media> entities, string title)
        {
            return entities.Where(m => m.Title.ToUpper().Contains(title.ToUpper()));
        }

        public static IQueryable<Media> FilterByPrice(this IQueryable<Media> entities, float price)
        {
            return entities.Where(m => m.Price <= price);
        }
    }
}
