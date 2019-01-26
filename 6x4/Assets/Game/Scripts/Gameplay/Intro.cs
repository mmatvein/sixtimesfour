namespace Game.Scripts.Gameplay
{
	using UnityEngine;
	using Zenject;

	public class Intro : MonoBehaviour
	{
		[Inject] ISceneDirector sceneDirector = default;

		public void OnIntroAnimationDone()
		{
			this.sceneDirector.CurrentSceneDone();
		}
	}
}