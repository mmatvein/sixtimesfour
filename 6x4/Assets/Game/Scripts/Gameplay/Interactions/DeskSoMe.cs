namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class DeskSoMe : Interaction
	{

		[Inject] PlayerMover playerMover = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;

		void Start()
		{

		}

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position);


		}
        
	}
}