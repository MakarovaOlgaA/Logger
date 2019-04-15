namespace Infrastructure.Resolving
{
    public interface IServiceLocator
    {
        T GetService<T>();
    }
}
