namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class FriendInteraction : Interaction
	{
		[SerializeField] Animator friendAnimator = default;
		[Inject] PlayerMover playerMover = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;

		void Start()
		{

		}

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position);


			this.talkTofriend();
		}

		void talkTofriend()
		{
            friendAnimator.SetBool("Talking", true);
			
		}
	}
}