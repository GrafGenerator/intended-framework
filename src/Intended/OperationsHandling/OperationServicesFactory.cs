using Intended.Abstractions.OperationsHandling;
using Intended.DependencyInjection;

namespace Intended.OperationsHandling
{
    internal class OperationServicesFactory : IOperationServicesFactory
    {
        private readonly IDiContainerAccessor _containerAccessor;

        public OperationServicesFactory(IDiContainerAccessor containerAccessor)
        {
            _containerAccessor = containerAccessor;
        }

        public IOperationService<TCommand, TResult> Get<TCommand, TResult>()
            where TCommand : class, IOperationServiceCommand
            where TResult : class, IOperationResult
        {
            var operationHandler = _containerAccessor.GetInstance<IOperationService<TCommand, TResult>>();
            return operationHandler;
        }
    }
}