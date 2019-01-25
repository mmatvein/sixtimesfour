namespace Zenject
{
    public abstract class InstallerBase : IInstaller
    {
        [Inject]
        DiContainer _container = default;

        protected DiContainer Container
        {
            get { return _container; }
        }

        public virtual bool IsEnabled
        {
            get { return true; }
        }

        public abstract void InstallBindings();
    }
}

