using FormationASPNETCore.Entities;
using FormationASPNETCore.Entities;

namespace FormationASPNETCore.Extensions
{

    public static class PublisherExtensions
    {

        public static IQueryable<Publisher> FilterByName(this IQueryable<Publisher> entities, string name)
        {
            return entities.Where(p => p.Name == name).OrderBy(a => a.Name);
        }
    }
}
