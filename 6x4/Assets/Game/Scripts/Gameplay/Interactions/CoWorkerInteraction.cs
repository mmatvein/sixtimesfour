namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class CoWorkerInteraction : Interaction
	{
		[SerializeField] Animator CoworkerAnimator= default;
		[Inject] PlayerMover playerMover = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;

		void Start()
		{

		}

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position-Vector3.right);


			this.talkTofriend();
		}

		void talkTofriend()
		{
            CoworkerAnimator.SetBool("Talking", true);
			
		}
	}
}