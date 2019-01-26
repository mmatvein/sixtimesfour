namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class BedInteraction : Interaction
	{
		[SerializeField] GameObject unmadeGameObject = default;
		[SerializeField] GameObject madeGameObject = default;
		[Inject] PlayerMover playerMover = default;
		
		void Start()
		{
			this.SetBedMade(false);
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