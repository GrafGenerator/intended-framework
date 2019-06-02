namespace Intended.DependencyInjection
{
    public interface IDiContainerAccessor
    {
        T GetInstance<T>() where T: class;
    }
}