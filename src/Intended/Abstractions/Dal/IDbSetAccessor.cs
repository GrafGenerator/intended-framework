using System.Linq;

namespace Intended.Abstractions.Dal
{
    public interface IDbSetAccessor<TEntity>
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        IQueryable<TEntity> Tracked();
        IQueryable<TEntity> NotTracked();
    }
}