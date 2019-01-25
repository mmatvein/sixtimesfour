using System.Collections;
using Game.Scripts.Core;
using UnityEngine;

namespace Game.Scripts.Gameplay
{
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private Animator animator = default;
        [SerializeField] private float moveSpeed = default;

        public IEnumerator MoveToPosition(Vector3 newPosition)
        {
            animator.SetTrigger("Walk");

            var position = transform.position;
            var moveDuration = (newPosition - position).magnitude / moveSpeed;
            yield return Tweening.TweenPosition(transform, position, newPosition,
                AnimationCurve.Linear(0, 0, 1, 1), moveDuration);
        }
    }
}