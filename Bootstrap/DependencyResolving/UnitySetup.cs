namespace Bootstrap.DependencyResolving
{
    using Infrastructure.Resolving;
    using System;
    using Unity;
    using Unity.Injection;

    public static class UnitySetup
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        public static IUnityContainer Container => container.Value;
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<IServiceLocator>(new InjectionFactory(c => CreateFactory()));
            container.RegisterType<ILoggerFactory, FileLoggerFactory>("FileLogger");

        }

        public static IServiceLocator CreateFactory()
        {
            return new ServiceLocator(container.Value);
        }
    }
}
