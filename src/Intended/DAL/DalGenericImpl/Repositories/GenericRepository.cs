using Intended.Abstractions.Dal;
using Intended.Abstractions.Domain;

namespace Intended.DAL.DalGenericImpl.Repositories
{
    internal class GenericEntityRepository<T> : IRepository<T>
        where T : class, IEntity

    {
        private readonly IDbContextAccessor _contextAccessor;
        private readonly IDbSetAccessor<T> _setAccessor;

        public GenericEntityRepository(IDbContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
            _setAccessor = contextAccessor.Set<T>();
        }

        public void Add(T entity)
        {
            _setAccessor.Add(entity);
        }

        public void Update(T entity)
        {
            // classic EF requires none here, if object is tracked
        }

        public void Delete(T entity)
        {
            _setAccessor.Remove(entity);
        }
    }
}