namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class FriendInteraction : Interaction
	{
		[SerializeField] Animator friendAnimator = default;
		[Inject] PlayerMover playerMover = default;
		static readonly int TALKING = Animator.StringToHash("Talking");

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position-Vector3.left);

			this.TalkToFriend();
		}

		void TalkToFriend()
		{
			this.friendAnimator.SetBool(TALKING, true);
			
		}
	}
}