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

		static readonly int ANIMATION_WALKING = Animator.StringToHash("Walking");
		static readonly int ANIMATION_FACING_LEFT = Animator.StringToHash("FacingLeft");


		public IEnumerator MoveToPosition(Vector3 newPosition)
		{
			newPosition.x = Mathf.Clamp(newPosition.x, this.minX, this.maxX);
			newPosition.y = this.yPos;
			newPosition.z = this.zPos;

			var playerTransform = this.transform;
			var position = playerTransform.position;

			this.animator.SetBool(ANIMATION_FACING_LEFT, newPosition.x <= position.x);
			this.animator.SetBool(ANIMATION_WALKING, true);

			var moveDuration = (newPosition - position).magnitude / this.moveSpeed;
			yield return Tweening.TweenPosition(
				playerTransform,
				position,
				newPosition,
				this.movementCurve,
				moveDuration);

			this.animator.SetBool(ANIMATION_WALKING, false);
		}
	}
}