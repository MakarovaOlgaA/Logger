namespace Bootstrap.DependencyResolving
{
    using Unity;
    using Infrastructure.Resolving;

    public class ServiceLocator : IServiceLocator
    {
        private readonly IUnityContainer container;

        public ServiceLocator(IUnityContainer container)
        {
            this.container = container;
        }

        public T GetService<T>()
        {
            return container.Resolve<T>();
        }
    }
}
