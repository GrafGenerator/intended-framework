using System.Threading.Tasks;

namespace Intended.Abstractions.Dal
{
    public interface IDbContextAccessor
    {
        IDbSetAccessor<T> Set<T>();

        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}