namespace Game.Scripts.Gameplay
{
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "New Dialog Item", menuName = "6x4/Dialog Item")]
	public class DialogItem : ScriptableObject
	{
		public string speech;
		public List<string> buttonTexts;
	}
}