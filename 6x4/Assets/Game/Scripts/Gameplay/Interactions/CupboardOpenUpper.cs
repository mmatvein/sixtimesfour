namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class CupboardOpenUpper : Interaction
	{
		[SerializeField] Animator FriendTalking = default;

        [Inject] PlayerMover playerMover = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;

		void Start()
		{

		}

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position - Vector3.left);

			this.playerChoiceService.RecordChoice(PlayerChoice.Cupboard, PlayerChoiceValues.CUPBOARD_UPPER_OPEN);
			this.setCupBoard(PlayerChoiceValues.CUPBOARD_UPPER_OPEN);
		}

		void setCupBoard(int cupboard)
		{
           /* this.cupboardClosedObject.SetActive(cupboard == PlayerChoiceValues.CUPBOARD_CLOSED);
            this.cupboardUpperOpenObject.SetActive(cupboard == PlayerChoiceValues.CUPBOARD_UPPER_OPEN);
            this.cupboardLowerOpenObject.SetActive(cupboard == PlayerChoiceValues.CUPBOARD_LOWER_OPEN);*/
        }
	}
}