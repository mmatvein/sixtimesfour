namespace Game.Scripts.Gameplay.SceneSetups
{
	using System;
	using UnityEngine;
	using Zenject;

	public class AvailableScenes : ScriptableObjectInstaller
	{
		public SceneDefinition[] sceneList;
		public SceneDefinition epilogueScene;

		public override void InstallBindings()
		{
			this.Container.BindInstance(this);
		}

		[Serializable]
		public class SceneDefinition
		{
			public string sceneName;
			[TextArea] public string interludeText;
		}
	}
}