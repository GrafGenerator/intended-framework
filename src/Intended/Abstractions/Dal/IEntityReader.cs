using System.Linq;
using Intended.Abstractions.Domain;

namespace Intended.Abstractions.Dal
{
    // ReSharper disable once TypeParameterCanBeVariant
    public interface IEntityReader<TEntity> : IQueryable<TEntity>
        where TEntity : class, IEntity
    {
        IQueryable<TEntity> WithTracking();
    }
}