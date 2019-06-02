using System.Threading.Tasks;
using Intended.Domain;

namespace Intended.DAL
{
    public interface IDbContextAccessor
    {
        IDbSetAccessor<T> Set<T>() 
            where T : class, IEntity;

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}