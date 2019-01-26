namespace Game.Scripts.Core
{
	using System;
	using System.Collections;
	using System.Threading.Tasks;
	using UnityEngine;

	public class CoroutineRunner : MonoBehaviour
	{
		public void RunCoroutine(IEnumerator coroutine)
		{
			this.StartCoroutine(coroutine);
		}

		public Task<bool> RunCoroutineAsTask(IEnumerator coroutine)
		{
			var tsc = new TaskCompletionSource<bool>();
			this.StartCoroutine(WrapCoroutineToBeUsedAsTask(coroutine, () => tsc.TrySetResult(true)));

			return tsc.Task;
		}

		static IEnumerator WrapCoroutineToBeUsedAsTask(IEnumerator coroutine, Action callback)
		{
			yield return coroutine;
			callback();
		}
	}
}