using FormationASPNETCore.Entities;
using FormationASPNETCore.Exceptions;

namespace FormationASPNETCore.Extensions
{
    public static class EntityExtensions
    {
        public static TEntity? GetById<TEntity>(this IQueryable<TEntity> entities, long id) where TEntity : IEntity
        {
            return entities.FirstOrDefault(e => e.Id == id);
        }

        public static TEntity GetByIdOrThrow<TEntity>(this IQueryable<TEntity> entities, long id) where TEntity : IEntity
        {
            TEntity? entity = entities.FirstOrDefault(e => e.Id == id);

            if (entity == null)
            {
                throw new NotFoundException<TEntity>(id);
            }

            return entity;
        }

        public static IQueryable<TEntity> GetByIds<TEntity>(this IQueryable<TEntity> entities, IList<long> ids) where TEntity : IEntity
        {
            return entities.Where(e => ids.Contains(e.Id));
        }
    }
}
