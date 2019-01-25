using System.Collections;
using UnityEngine;

namespace Game.Scripts.Core
{
    public static class Tweening
    {
        public static IEnumerator TweenPosition(Transform transformToTween, Vector3 from, Vector3 to,
            AnimationCurve curve, float duration)
        {
            if (duration <= 0)
            {
                transformToTween.position = to;
                yield break;    
            }
            
            transformToTween.position = from;

            float t = 0;
            while (t <= duration)
            {
                t += Time.deltaTime;

                var evaluatedTime = curve.Evaluate(t/duration);
                transformToTween.position = Vector3.Lerp(from, to, evaluatedTime);

                yield return null;
            }

            transformToTween.position = to;
        }
    }
}