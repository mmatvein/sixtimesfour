namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using TMPro;
	using UnityEngine;
	using Zenject;

	public class EveningSceneRunner : SceneRunner
	{
		protected override IEnumerator HandleResult(PlayerChoice choice, int choiceValue)
		{
			yield break;
		}
	}
}