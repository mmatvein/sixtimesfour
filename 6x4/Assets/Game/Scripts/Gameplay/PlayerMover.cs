namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using Core;
	using UnityEngine;

	public class PlayerMover : MonoBehaviour
    {
        [SerializeField] Animator animator = default;
        [SerializeField] float moveSpeed = default;
		static readonly int WALK = Animator.StringToHash("Walk");

		public IEnumerator MoveToPosition(Vector3 newPosition)
        {
			this.animator.SetTrigger(WALK);

			var playerTransform = this.transform;
            var position = playerTransform.position;
            var moveDuration = (newPosition - position).magnitude / this.moveSpeed;
            yield return Tweening.TweenPosition(
				playerTransform, position, newPosition,
                AnimationCurve.Linear(0, 0, 1, 1), moveDuration);
        }
    }
}