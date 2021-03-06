namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class BedInteraction : Interaction
	{
		[SerializeField] GameObject unmadeGameObject = default;
		[SerializeField] GameObject madeGameObject = default;
		[SerializeField] bool forceBedUnmade = default;
		
		[Inject] PlayerMover playerMover = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;

		void Start()
		{
			var bedMade = !this.forceBedUnmade &&
				this.playerChoiceService.GetChoice(PlayerChoice.MadeBed, PlayerChoiceValues.BED_UNMADE) ==
				PlayerChoiceValues.BED_MADE;

			this.SetBedMade(bedMade);
		}

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position);
			
			this.SetBedMade(true);
		}

		void SetBedMade(bool isMade)
		{
			this.unmadeGameObject.SetActive(!isMade);
			this.madeGameObject.SetActive(isMade);
		}
	}
}