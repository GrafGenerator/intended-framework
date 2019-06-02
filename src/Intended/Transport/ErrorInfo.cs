using Intended.OperationsHandling;

namespace Intended.Transport
{
    public class ErrorInfo : IErrorInfo
    {
        public string Reason { get; }

        private ErrorInfo(string reason)
        {
            Reason = reason;
        }

        public static ErrorInfo FromReason(string reason)
        {
            return new ErrorInfo(reason);
        }
        
        public static ErrorInfo FromResult(IOperationResult result)
        {
            return new ErrorInfo(result.Error.Reason);
        }
    }
}