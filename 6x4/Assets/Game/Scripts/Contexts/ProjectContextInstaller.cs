namespace Game.Scripts.Contexts
{
	using Core;
	using Gameplay;
	using Input;
	using UI;
	using UnityEngine;
	using Zenject;

	public class ProjectContextInstaller : MonoInstaller
	{
		[SerializeField] Fader fader = default;
        public override void InstallBindings()
        {
			this.Container.Bind<IInputService>().To<InputService>().AsSingle();
			this.Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
			this.Container.Bind<IPlayerChoiceService>().To<PlayerChoiceService>().AsSingle();
			this.Container.Bind<ISceneDirector>().To<SceneDirector>().AsSingle();
			this.Container.BindInstance(this.GetComponent<CoroutineRunner>());
			this.Container.BindInstance(this.fader);
		}
    }
}