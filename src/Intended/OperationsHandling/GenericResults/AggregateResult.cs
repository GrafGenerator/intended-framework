using System.Linq;

namespace Intended.OperationsHandling.GenericResults
{
    public class AggregateResult: OperationResult
    {
        public IOperationResult[] Results { get; }

        public AggregateResult(params IOperationResult[] results)
        {
            Results = results;
        }

        public T Some<T>()
            where T: class, IOperationResult
        {
            return Results.OfType<T>().FirstOrDefault();
        }
    }

    public static class Aggregated
    {
        public static AggregateResult Results(params IOperationResult[] results)
        {
            return new AggregateResult(results).IsOk();
        }
    }
}