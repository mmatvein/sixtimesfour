namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using TMPro;
	using UnityEngine;
	using Zenject;

	public class WorkSceneRunner : SceneRunner
	{
		protected override IEnumerator HandleResult(int playerChoice)
		{
			yield break;
		}
	}
}