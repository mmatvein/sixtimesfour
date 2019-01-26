namespace Game.Scripts.Gameplay
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "New Dialog Item", menuName = "6x4/Dialog Item")]
	public class DialogItem : ScriptableObject
	{
		public List<Precondition> preconditions;
		public string speech;
		public List<string> buttonTexts;

		[Serializable]
		public class Precondition
		{
			public PlayerChoice choice;
			public int choiceValue;
			public int assumedChoiceValue;
		}
	}
}