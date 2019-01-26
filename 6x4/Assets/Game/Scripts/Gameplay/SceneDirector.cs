namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using System.Collections.Generic;
	using Core;
	using SceneSetups;
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

		readonly Queue<string> scenes = new Queue<string>();

		public SceneDirector(CoroutineRunner coroutineRunner, AvailableScenes availableScenes)
		{
			this.coroutineRunner = coroutineRunner;
			this.availableScenes = availableScenes;
		}

		public void CurrentSceneDone()
		{
			this.coroutineRunner.RunCoroutine(this.LoadNextScene());
		}

		IEnumerator LoadNextScene()
		{
			var nextScene = this.GetNextScene(); 
			
			var currentActiveScene = SceneManager.GetActiveScene();
			SceneManager.UnloadSceneAsync(currentActiveScene);
			yield return SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene));	
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