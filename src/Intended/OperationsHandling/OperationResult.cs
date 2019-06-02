using Intended.Transport;

namespace Intended.OperationsHandling
{
    public class OperationResult: IOperationResult
    {
        public OperationResult()
        {
        }

        public OperationResult(bool success)
        {
            Success = success;
        }

        public bool Success { get; private set; }
        
        public IErrorInfo Error { get; private set; }

        internal OperationResult UpdateSuccess(bool value)
        {
            Success = value;
            return this;
        }
        
        internal OperationResult SetError(string reason)
        {
            Error = ErrorInfo.FromReason(reason);
            return this;
        } 
    }

    public static class OperationResultExtensions
    {
        public static T IsOk<T>(this T operationResult) where T : OperationResult
        {
            return (T) operationResult.UpdateSuccess(true);
        }

        public static T IsFailed<T>(this T operationResult) where T : OperationResult
        {
            return (T) operationResult.UpdateSuccess(false);
        }

        public static T WithError<T>(this T operationResult, string reason) where T : OperationResult
        {
            return (T) operationResult.SetError(reason);
        }

        public static T WithError<T>(this T operationResult, ErrorInfo errorInfo) where T : OperationResult
        {
            return (T) operationResult.SetError(errorInfo.Reason);
        }
    }
}