namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using Core;
	using UnityEngine;

	public class PlayerMover : MonoBehaviour
	{
		[SerializeField] Animator animator = default;
		[SerializeField] float moveSpeed = default;
		[SerializeField] AnimationCurve movementCurve = default;
		[SerializeField] float minX = default;
		[SerializeField] float maxX = default;
		[SerializeField] float yPos = default;
		[SerializeField] float zPos = -0.1f;

		static readonly int WALK = Animator.StringToHash("Walk");


		public IEnumerator MoveToPosition(Vector3 newPosition)
		{
			newPosition.x = Mathf.Clamp(newPosition.x, this.minX, this.maxX);
			newPosition.y = this.yPos;
			newPosition.z = this.zPos;

			this.animator.SetTrigger(WALK);

			var playerTransform = this.transform;
			var position = playerTransform.position;
			var moveDuration = (newPosition - position).magnitude / this.moveSpeed;
			yield return Tweening.TweenPosition(
				playerTransform,
				position,
				newPosition,
				this.movementCurve,
				moveDuration);
		}
	}
}