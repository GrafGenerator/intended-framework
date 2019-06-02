using Intended.Domain;

namespace Intended.OperationsHandling
{
    public interface IEntityIdentityService
    {
        void SetId(IEntity entity);
    }
}