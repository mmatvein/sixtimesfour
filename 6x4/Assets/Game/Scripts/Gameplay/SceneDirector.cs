namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using Core;
	using UnityEngine.SceneManagement;

	public interface ISceneDirector
	{
		void CurrentSceneDone();
	}
	
	public class SceneDirector : ISceneDirector
	{
		readonly CoroutineRunner coroutineRunner;

		public SceneDirector(CoroutineRunner coroutineRunner) => this.coroutineRunner = coroutineRunner;

		public void CurrentSceneDone()
		{
			this.coroutineRunner.RunCoroutine(this.LoadNextScene());
		}

		IEnumerator LoadNextScene()
		{
			var currentActiveScene = SceneManager.GetActiveScene();
			SceneManager.UnloadSceneAsync(currentActiveScene);
			yield return SceneManager.LoadSceneAsync("MorningScene", LoadSceneMode.Additive);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName("MorningScene"));	
		}
	}
}