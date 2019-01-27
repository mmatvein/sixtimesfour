namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using TMPro;
	using UnityEngine;
	using Zenject;

	public class WorkSceneRunner : SceneRunner
	{
		[SerializeField] Vector3 computerPos = default;
		[Inject] PlayerMover playerMover = default;
		protected override IEnumerator HandleResult(PlayerChoice choice, int choiceValue)
		{
			if (choice == PlayerChoice.Coworker)
			{
				yield return new WaitForSeconds(0.5f);
			}
			else if (choice == PlayerChoice.Computer)
			{
				yield return this.playerMover.MoveToPosition(this.computerPos);
			}
		}
	}
}