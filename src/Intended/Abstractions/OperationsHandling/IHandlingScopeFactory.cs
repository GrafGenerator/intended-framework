namespace Intended.Abstractions.OperationsHandling
{
    public interface IHandlingScopeFactory
    {
        IHandlingScope Enter(HandlerIdentity identity);
    }
}