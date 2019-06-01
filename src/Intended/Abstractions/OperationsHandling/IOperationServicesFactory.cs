namespace Intended.Abstractions.OperationsHandling
{
    public interface IOperationServicesFactory
    {
        IOperationService<TCommand, TResult> Get<TCommand, TResult>()
            where TCommand : class, IOperationServiceCommand
            where TResult : class, IOperationResult;
    }
}