namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using System.Collections.Generic;
	using Core;
	using SceneSetups;
	using UI;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public interface ISceneDirector
	{
		void CurrentSceneDone();
	}
	
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
				this.RandomizeNewSceneCycle();

			return this.scenes.Dequeue();
		}

		void RandomizeNewSceneCycle()
		{
			var scenes = new List<string>(this.availableScenes.sceneList);

			while (scenes.Count > 0)
			{
				int index = Random.Range(0, scenes.Count);
				this.scenes.Enqueue(scenes[index]);
				scenes.RemoveAt(index);
			}
		}
	}
}