using System.Linq;
using Intended.Domain;

namespace Intended.DAL
{
    public interface IDbSetAccessor<TEntity>
        where TEntity: class, IEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);

        IQueryable<TEntity> Tracked();
        IQueryable<TEntity> NotTracked();
    }
}