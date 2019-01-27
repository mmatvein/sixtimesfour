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
				var result = await this.speechBubble.ShowAsync(
					this.dialogItem.speech,
					this.dialogItem.buttons.Select(button => button.text).ToArray());

				var chosenButton = this.dialogItem.buttons[result];
                var reaction = this.dialogItem.buttons[result].reactionText;
				this.playerChoiceService.RecordChoice(chosenButton.choice, chosenButton.choiceValue);

				Debug.Log("Result: " + result);

				await this.coroutineRunner.RunCoroutineAsTask(this.HandleResult(result));

                this.speechBubble.flush();
                this.showReaction(reaction);
                //siirretty näyttämään reaktioteksti. Currentscenedone siirretty sen alle. Se varmaan ajetaan muutenki vasta ku kaikki tekstit on ajettu.
				//this.sceneDirector.CurrentSceneDone();
			}
			catch (Exception e)
			{
				Debug.LogException(e);
			}
		}

        async void showReaction(string reaction)
        {
            try
            {
                var result = await this.speechBubble.ShowAsync(reaction, new string[]{"ok"});
                this.sceneDirector.CurrentSceneDone();
            }
            catch(Exception e)
            {
                Debug.LogException(e);
            }
        }
		protected abstract IEnumerator HandleResult(int playerChoice);
	}
}
