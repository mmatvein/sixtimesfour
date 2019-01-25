namespace Game.Scripts.Contexts
{
	using Core;
	using Input;
	using Zenject;

	public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
			this.Container.Bind<IInputService>().To<InputService>().AsSingle();
			this.Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}