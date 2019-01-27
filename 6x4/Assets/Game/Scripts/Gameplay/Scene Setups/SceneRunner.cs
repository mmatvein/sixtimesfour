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
		[Inject] DialogItem dialogItem = default;
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
				var chosenButton = await this.speechBubble.ShowAsync(
					this.dialogItem.speech,
					this.dialogItem.buttons
						.FilterForPreconditions(
							 this.playerChoiceService,
							 button => button.preconditions)
						.ToArray());

				this.playerChoiceService.RecordChoice(chosenButton.choice, chosenButton.choiceValue);

				Debug.Log("Result: " + chosenButton.text);

				await this.coroutineRunner.RunCoroutineAsTask(this.HandleResult(chosenButton.choiceValue));
				
				var reaction = chosenButton.reactionText;
				if (!string.IsNullOrEmpty(reaction))
				{
					await this.ShowReaction(reaction);
				}

				this.sceneDirector.CurrentSceneDone();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}

		async Task ShowReaction(string reaction)
		{
			await this.speechBubble.ShowAsync(reaction, new DialogItem.Button { text = "Ok." });
		}

		protected abstract IEnumerator HandleResult(int playerChoice);
	}
}