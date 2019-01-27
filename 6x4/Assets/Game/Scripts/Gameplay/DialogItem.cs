namespace Game.Scripts.Gameplay
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "New Dialog Item", menuName = "6x4/Dialog Item")]
	public class DialogItem : ScriptableObject
	{
		public List<Precondition> preconditions;
		[TextArea] public string speech;
		public List<Button> buttons;

		[Serializable]
		public class Precondition
		{
			public PlayerChoice choice;
			public int choiceValue;
			public int assumedChoiceValue;
		}

		[Serializable]
		public class Button
		{
			public string text;
            [TextArea] public string reactionText;
			public PlayerChoice choice;
			public int choiceValue;
            public List<Precondition> preconditions;
		}
	}
}