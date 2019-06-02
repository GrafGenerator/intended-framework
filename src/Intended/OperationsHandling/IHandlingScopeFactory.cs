namespace Intended.OperationsHandling
{
    public interface IHandlingScopeFactory
    {
        IHandlingScope Enter(HandlerIdentity identity);
    }
}