using Intended.Transport;

namespace Intended.OperationsHandling
{
    public interface IOperationResult
    {
        bool Success { get; }
        IErrorInfo Error { get; }
    }
}