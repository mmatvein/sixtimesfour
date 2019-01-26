namespace Game.Scripts.Gameplay.SceneSetups
{
	using Zenject;

	public class AvailableScenes : ScriptableObjectInstaller
	{
		public string[] sceneList;

		public override void InstallBindings()
		{
			this.Container.BindInstance(this);
		}
	}
}