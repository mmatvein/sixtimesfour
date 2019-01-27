namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using Zenject;

	public class DeskWork : Interaction
	{
		[Inject] PlayerMover playerMover = default;

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position);
		}
	}
}