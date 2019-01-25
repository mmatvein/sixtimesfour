using Game.Scripts.Core;
using Game.Scripts.Input;
using Zenject;

namespace Game.Scripts.Contexts
{
    public class ProjectContextInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IInputService>().To<InputService>().AsSingle();
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }
    }
}