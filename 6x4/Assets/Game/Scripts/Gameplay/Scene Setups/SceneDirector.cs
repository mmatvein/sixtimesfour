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
		readonly IPlayerChoiceService playerChoiceService;

		readonly Queue<AvailableScenes.SceneDefinition> scenes = new Queue<AvailableScenes.SceneDefinition>();
		int iterationIndex = 0;

		public SceneDirector(
			CoroutineRunner coroutineRunner,
			AvailableScenes availableScenes,
			Fader fader,
			IPlayerChoiceService playerChoiceService)
		{
			this.coroutineRunner = coroutineRunner;
			this.availableScenes = availableScenes;
			this.fader = fader;
			this.playerChoiceService = playerChoiceService;
		}

		public void CurrentSceneDone()
		{
			this.coroutineRunner.RunCoroutine(this.LoadNextScene());
		}

		IEnumerator LoadNextScene()
		{
			var nextScene = this.GetNextScene();
			
			this.fader.ShowFade(nextScene.interludeText);

			yield return new WaitForSeconds(2.0f);

			var currentActiveScene = SceneManager.GetActiveScene();
			SceneManager.UnloadSceneAsync(currentActiveScene);
			yield return SceneManager.LoadSceneAsync(nextScene.sceneName, LoadSceneMode.Additive);
			SceneManager.SetActiveScene(SceneManager.GetSceneByName(nextScene.sceneName));

			yield return new WaitForSeconds(1.0f);

			this.fader.HideFade();
		}

		AvailableScenes.SceneDefinition GetNextScene()
		{
			if (this.ShouldShowEpilogue())
			{
				return this.availableScenes.epilogueScene;
			}

			if (this.scenes.Count == 0)
			{
				this.RandomizeNewSceneCycle();
			}

			return this.scenes.Dequeue();
		}

		void RandomizeNewSceneCycle()
		{
			this.iterationIndex++;

			foreach (var scene in this.availableScenes.sceneList)
			{
				this.scenes.Enqueue(scene);
			}
		}

		bool ShouldShowEpilogue() =>
			this.PlayerHasChosenCorrectMomValue() ||
			this.scenes.Count == 0 && this.iterationIndex > 3;

		bool PlayerHasChosenCorrectMomValue() =>
			this.playerChoiceService.GetChoice(
				PlayerChoice.Mom, 
				PlayerChoiceValues.MOM_NEUTRAL) ==
			PlayerChoiceValues.MOM_HOME;
	}
}