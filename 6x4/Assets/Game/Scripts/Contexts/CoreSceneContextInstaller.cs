using Game.Scripts.Gameplay;
using SixTimesFour.Core;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Contexts
{
    public class CoreSceneContextInstaller : MonoInstaller
    {
        [SerializeField] private Camera mainCamera = default;
        [SerializeField] private Camera uiCamera = default;
        [SerializeField] private PlayerMover playerMover = default;
        
        public override void InstallBindings()
        {
            Container.BindInstance(mainCamera).WithId(Cameras.Main);
            Container.BindInstance(uiCamera).WithId(Cameras.UI);
            Container.BindInstances(playerMover)    ;
        }
    }
}