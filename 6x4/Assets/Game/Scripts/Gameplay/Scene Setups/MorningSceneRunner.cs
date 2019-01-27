namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class MorningSceneRunner : SceneRunner
	{
		[Inject] BedInteraction bedInteraction = default;
		[Inject] CupboardOpenUpper cupboardOpenUpperInteraction = default;
		[Inject] CupboardOpenLower cupboardOpenLowerInteraction = default;
		[Inject] PlayerMover playerMover = default;

		protected override IEnumerator HandleResult(PlayerChoice choice, int choiceValue)
		{
			if (choice == PlayerChoice.MadeBed)
			{
				switch (choiceValue)
				{
					case PlayerChoiceValues.BED_MADE:
						yield return this.bedInteraction.RunInteraction();
						yield break;
					case PlayerChoiceValues.BED_UNMADE:
						yield return this.playerMover.MoveToPosition(new Vector3(3, 0, 0));
						yield break;
				}
			}
			else if (choice == PlayerChoice.Cupboard)
			{
				switch (choiceValue)
				{
					case PlayerChoiceValues.CUPBOARD_LOWER_OPEN:
						yield return this.cupboardOpenLowerInteraction.RunInteraction();
						yield break;
					case PlayerChoiceValues.CUPBOARD_UPPER_OPEN:
						yield return this.cupboardOpenUpperInteraction.RunInteraction();
						yield break;
					default:
						yield return this.playerMover.MoveToPosition(new Vector3(5, 0, 0));
						yield break;
				}
			}
		}
	}
}