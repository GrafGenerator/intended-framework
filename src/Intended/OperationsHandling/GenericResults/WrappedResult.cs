namespace Intended.OperationsHandling.GenericResults
{
    public class WrappedResult<T>: OperationResult
    {
        public T InnerResult { get; }

        internal WrappedResult(T innerResult)
        {
            InnerResult = innerResult;
        }
    }

    public static class Wrap
    {
        public static WrappedResult<TResult> For<TResult>(TResult result)
        {
            return new WrappedResult<TResult>(result).IsOk();
        }
    }
}