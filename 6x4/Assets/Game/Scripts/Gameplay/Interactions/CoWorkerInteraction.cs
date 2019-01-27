namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class CoWorkerInteraction : Interaction
	{
		[SerializeField] Animator CoworkerAnimator = default;
		[Inject] PlayerMover playerMover = default;
		static readonly int TALKING = Animator.StringToHash("Talking");

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position-Vector3.right);

			this.TalkToFriend();
		}

		void TalkToFriend()
		{
			this.CoworkerAnimator.SetBool(TALKING, true);
			
		}
	}
}