using Intended.Domain;

namespace Intended.DAL
{
    public interface IRepository<T>
        where T : class, IEntity
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}