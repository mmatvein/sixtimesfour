namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;

	public abstract class Interaction : MonoBehaviour
	{
		public abstract IEnumerator RunInteraction();
	}
}