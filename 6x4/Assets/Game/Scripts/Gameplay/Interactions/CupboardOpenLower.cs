namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class CupboardOpenLower : Interaction
	{
		[SerializeField] GameObject cupboardClosedObject = default;
		[SerializeField] GameObject cupboardUpperOpenObject = default;
        [SerializeField] GameObject cupboardLowerOpenObject = default;
        [Inject] PlayerMover playerMover = default;

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position);

			this.SetCupBoard(PlayerChoiceValues.CUPBOARD_LOWER_OPEN);
		}

		void SetCupBoard(int cupboard)
		{
			this.cupboardClosedObject.SetActive(cupboard == PlayerChoiceValues.CUPBOARD_CLOSED);
			this.cupboardUpperOpenObject.SetActive(cupboard == PlayerChoiceValues.CUPBOARD_UPPER_OPEN);
            this.cupboardLowerOpenObject.SetActive(cupboard == PlayerChoiceValues.CUPBOARD_LOWER_OPEN);
		}
	}
}