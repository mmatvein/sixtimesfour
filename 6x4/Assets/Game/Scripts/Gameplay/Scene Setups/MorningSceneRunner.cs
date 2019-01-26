namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class MorningSceneRunner : SceneRunner
	{
		[Inject] BedInteraction bedInteraction = default;
		[Inject] PlayerMover playerMover = default;

		protected override IEnumerator HandleResult(int playerChoice) =>
			playerChoice == PlayerChoiceValues.BED_MADE
				? this.bedInteraction.RunInteraction()
				: this.playerMover.MoveToPosition(new Vector3(9, 0, 0));
	}
}