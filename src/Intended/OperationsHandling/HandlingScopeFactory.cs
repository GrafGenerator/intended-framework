using Intended.DependencyInjection;

namespace Intended.OperationsHandling
{
    internal class HandlingScopeFactory : IHandlingScopeFactory
    {
        private readonly IDiContainerAccessor _containerAccessor;

        public HandlingScopeFactory(IDiContainerAccessor containerAccessor)
        {
            _containerAccessor = containerAccessor;
        }

        public IHandlingScope Enter(HandlerIdentity identity)
        {
            return new HandlingScope(_containerAccessor, identity);
        }
    }
}