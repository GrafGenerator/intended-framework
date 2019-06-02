using System.Threading.Tasks;

namespace Intended.OperationsHandling
{
    public interface IOperationService<TCommand, TResult>
        where TCommand: class, IOperationServiceCommand
        where TResult: class, IOperationResult
    {
        Task<TResult> Handle(TCommand command);
    }
}