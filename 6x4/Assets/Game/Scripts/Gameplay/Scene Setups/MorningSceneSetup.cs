namespace Game.Scripts.SceneSetups
{
	using Gameplay;
	using UI;
	using UnityEngine;
	using Zenject;

	public class MorningSceneSetup : MonoBehaviour
	{
		[Inject] SpeechBubble speechBubble = default;
		[Inject] DialogItem dialogItem = default;
		[Inject] BedInteraction bedInteraction = default;
		[Inject] PlayerMover playerMover = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;
		
		void Start()
		{
			this.RunDialog();
		}

		async void RunDialog()
		{
			var result = await this.speechBubble.ShowAsync(this.dialogItem.speech, this.dialogItem.buttonTexts.ToArray());

			var chosenButton = this.dialogItem.buttons[result];
			this.playerChoiceService.RecordChoice(chosenButton.choice, chosenButton.choiceValue);

			Debug.Log("Result: " + result);
			
			if (result == 0)
			{
				this.StartCoroutine(this.bedInteraction.RunInteraction());
			}
			else
			{
				this.StartCoroutine(this.playerMover.MoveToPosition(new Vector3(9, 0, 0)));
			}
		}
	}
}