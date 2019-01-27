namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using System.Collections.Generic;
	using Core;
	using JetBrains.Annotations;
	using SceneSetups;
	using UI;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public interface ISceneDirector
	{
		void CurrentSceneDone();
	}
	
	[UsedImplicitly]
	public class SceneDirector : ISceneDirector
	{
		readonly CoroutineRunner coroutineRunner;
		readonly AvailableScenes availableScenes;
		readonly Fader fader;

		readonly Queue<string> scenes = new Queue<string>();

		public SceneDirector(CoroutineRunner coroutineRunner, AvailableScenes availableScenes, Fader fader)
		{
			this.coroutineRunner = coroutineRunner;
			this.availableScenes = availableScenes;
			this.fader = fader;
		}

		public void CurrentSceneDone()
		{
			this.coroutineRunner.RunCoroutine(this.LoadNextScene());
		}

		IEnumerator LoadNextScene()
		{
			this.fader.ShowFade();

			yield return new WaitForSeconds(2.0f);
			
			var nextScene = this.GetNextScene(); 
			
			var currentActiveScene = SceneManager.GetActiveScene();
			SceneManager.UnloadSceneAsync(currentActiveScene);
			yield return SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));

			yield return new WaitForSeconds(1.0f);
			
			this.fader.HideFade();
		}

		string GetNextScene()
		{
			if (this.scenes.Count == 0)
			{
				this.RandomizeNewSceneCycle();
			}

			return this.scenes.Dequeue();
		}

		void RandomizeNewSceneCycle()
		{
			var scenesForRandomization = new List<string>(this.availableScenes.sceneList);

			while (scenesForRandomization.Count > 0)
			{
				var index = Random.Range(0, scenesForRandomization.Count);
				this.scenes.Enqueue(scenesForRandomization[index]);
				scenesForRandomization.RemoveAt(index);
			}
		}
	}
}