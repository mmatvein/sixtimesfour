namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using TMPro;
	using UnityEngine;
	using Zenject;

	public class StreetSceneRunner : SceneRunner
	{
		[SerializeField] Transform beggarTransform = default;
		[SerializeField] Vector3 talkToFriendPosition = default;
		[SerializeField] Vector3 offScreenPosition = default;
		[Inject] PlayerMover playerMover = default;
		
		protected override IEnumerator HandleResult(PlayerChoice choice, int choiceValue)
		{
			if (choice == PlayerChoice.Beggar)
			{
				if (choiceValue == PlayerChoiceValues.BEGGAR_GIVECOIN)
				{
					yield return this.playerMover.MoveToPosition(this.beggarTransform.position);
					yield return new WaitForSeconds(0.5f);
				}

				this.StartCoroutine(this.MoveToPosAfterTime(0.5f, this.talkToFriendPosition));
			}
			else if (choice == PlayerChoice.Friend)
			{
				this.StopAllCoroutines();
				this.StartCoroutine(this.MoveToPosAfterTime(1.5f, this.offScreenPosition));
			}
		}

		IEnumerator MoveToPosAfterTime(float timeToWait, Vector3 pos)
		{
			yield return new WaitForSeconds(timeToWait);
			yield return this.playerMover.MoveToPosition(pos);
		}
	}
}