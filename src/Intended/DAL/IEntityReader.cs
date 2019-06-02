using System.Linq;
using Intended.Domain;

namespace Intended.DAL
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IEntityReader<TEntity> : IQueryable<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> WithTracking();
    }
}