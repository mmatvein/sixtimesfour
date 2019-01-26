namespace Game.Scripts.Core
{
	using System.Collections;
	using UnityEngine;
	using UnityEngine.SceneManagement;

	public class SceneLoadingHook : MonoBehaviour
	{
		[SerializeField] string sceneToLoad = default;
		IEnumerator Start()
		{
			yield return SceneManager.LoadSceneAsync(this.sceneToLoad, LoadSceneMode.Additive);
			var scene = SceneManager.GetSceneByName(this.sceneToLoad);
			SceneManager.SetActiveScene(scene);
		}
	}
}