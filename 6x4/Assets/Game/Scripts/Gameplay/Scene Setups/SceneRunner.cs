using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.Gameplay.SceneSetups
{
	using System;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Threading;
	using System.Threading.Tasks;
	using Core;
	using UI;
	using Zenject;

	public abstract class SceneRunner : MonoBehaviour
	{
		[Inject] SpeechBubble speechBubble = default;
		[Inject] DialogItem[] dialogItems = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;
		[Inject] CoroutineRunner coroutineRunner = default;
		[Inject] ISceneDirector sceneDirector = default;

		void Start()
		{
			this.Run();
		}

		async void Run()
		{
			try
			{
				foreach (var dialogItem in this.dialogItems)
				{
					await this.ShowDialog(dialogItem);
				}

				this.sceneDirector.CurrentSceneDone();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}

		async Task ShowDialog(DialogItem dialogItem)
		{
			var chosenButton = await this.speechBubble.ShowAsync(
				dialogItem.speech,
				dialogItem.buttons
					.FilterForPreconditions(
						 this.playerChoiceService,
						 button => button.preconditions)
					.ToArray());

			if (chosenButton.choice != PlayerChoice.Undefined)
			{
				this.playerChoiceService.RecordChoice(chosenButton.choice, chosenButton.choiceValue);
			}

			Debug.Log("Result: " + chosenButton.text);

			await this.coroutineRunner.RunCoroutineAsTask(this.HandleResult(chosenButton.choice, chosenButton.choiceValue));
				
			var reaction = chosenButton.reactionText;
			if (!string.IsNullOrEmpty(reaction))
			{
				await this.ShowReaction(reaction);
			}
		}

		async Task ShowReaction(string reaction)
		{
			await this.speechBubble.ShowAsync(reaction);
		}

		protected abstract IEnumerator HandleResult(PlayerChoice choice, int choiceValue);
	}
}