using Intended.Abstractions.Domain;

namespace Intended.Abstractions.Dal
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}