using Intended.Abstractions.Domain;

namespace Intended.Abstractions.OperationsHandling
{
    public interface IEntityIdentityService
    {
        void SetId(IEntity entity);
    }
}