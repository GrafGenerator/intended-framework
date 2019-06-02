using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Intended.Domain;

namespace Intended.DAL
{
    internal class EntityReader<TEntity> : IEntityReader<TEntity> where TEntity : class, IEntity
    {
        private readonly IQueryable<TEntity> _queryable;
        private readonly IDbSetAccessor<TEntity> _setAccessor;

        public EntityReader(IDbContextAccessor contextAccessor)
        {
            _setAccessor = contextAccessor.Set<TEntity>();
            _queryable = _setAccessor.NotTracked();
        }

        public IQueryable<TEntity> WithTracking() => _setAccessor.Tracked();

        public IEnumerator<TEntity> GetEnumerator() => _queryable.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public Type ElementType => _queryable.ElementType;
        public Expression Expression => _queryable.Expression;
        public IQueryProvider Provider => _queryable.Provider;
    }
}