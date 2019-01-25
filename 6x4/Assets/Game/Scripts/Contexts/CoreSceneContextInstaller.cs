using SixTimesFour.Core;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Contexts
{
    public class CoreSceneContextInstaller : MonoInstaller
    {
        public Camera mainCamera;
        public Camera uiCamera;
        
        public override void InstallBindings()
        {
            Container.BindInstance(mainCamera).WithId(Cameras.Main);
            Container.BindInstance(uiCamera).WithId(Cameras.UI);
        }
    }
}