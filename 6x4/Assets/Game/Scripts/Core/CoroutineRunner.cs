namespace Game.Scripts.Core
{
	using System.Collections;
	using UnityEngine;

	public class CoroutineRunner : MonoBehaviour
	{
		public void RunCoroutine(IEnumerator coroutine)
		{
			this.StartCoroutine(coroutine);
		}
	}
}