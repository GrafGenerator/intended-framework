using Intended.Abstractions.Transport;

namespace Intended.Abstractions.OperationsHandling
{
    public interface IOperationResult
    {
        bool Success { get; }
        IErrorInfo Error { get; }
    }
}