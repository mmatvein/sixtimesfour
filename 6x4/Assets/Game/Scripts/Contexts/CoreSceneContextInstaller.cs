namespace Game.Scripts.Contexts
{
	using Gameplay;
	using SixTimesFour.Core;
	using UI;
	using UnityEngine;
	using Zenject;

	public class CoreSceneContextInstaller : MonoInstaller
    {
        [SerializeField] Camera mainCamera = default;
        [SerializeField] Camera uiCamera = default;
        [SerializeField] PlayerMover playerMover = default;
		[SerializeField] SpeechBubble speechBubble = default;
        
        public override void InstallBindings()
        {
			this.Container.BindInstance(this.mainCamera).WithId(Cameras.Main);
			this.Container.BindInstance(this.uiCamera).WithId(Cameras.Ui);
			this.Container.BindInstances(this.playerMover, this.speechBubble);
        }
    }
}