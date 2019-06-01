using System.Threading.Tasks;

namespace Intended.Abstractions.OperationsHandling
{
    public interface IOperationService<TCommand, TResult>
        where TCommand: class, IOperationServiceCommand
        where TResult: class, IOperationResult
    {
        Task<TResult> Handle(TCommand command);
    }
}