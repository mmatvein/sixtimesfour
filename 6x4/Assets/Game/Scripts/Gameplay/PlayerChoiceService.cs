namespace Game.Scripts.Gameplay
{
	using System;
	using System.Collections.Generic;
	using JetBrains.Annotations;
	using UnityEngine;

	public interface IPlayerChoiceService
	{
		void RecordChoice(PlayerChoice choice, int choiceValue);
		int GetChoice(PlayerChoice choice, int defaultValue);
	}

	[UsedImplicitly]
	public class PlayerChoiceService : IPlayerChoiceService
	{
		readonly Dictionary<PlayerChoice, int> choicesPlayerHasMade = new Dictionary<PlayerChoice, int>();
		const string SAVE_KEY = "Choices";

		public PlayerChoiceService()
		{
			this.LoadChoices();
		}

		public void RecordChoice(PlayerChoice choice, int choiceValue)
		{
			this.choicesPlayerHasMade[choice] = choiceValue;

			this.SaveChoices();
		}

		public int GetChoice(PlayerChoice choice, int defaultValue) =>
			this.choicesPlayerHasMade.TryGetValue(choice, out var result) ? result : defaultValue;

		void SaveChoices()
		{
			var serialized = new SerializedChoices();

			foreach (var choiceKvp in this.choicesPlayerHasMade)
			{
				serialized.choices.Add(
					new SerializedChoices.SerializedChoice
						{ choice = choiceKvp.Key.ToString(), choiceValue = choiceKvp.Value });
			}

			var json = JsonUtility.ToJson(serialized);
			
			Debug.Log("Saving choices: " + json);
			
			PlayerPrefs.SetString(SAVE_KEY, json);
		}

		void LoadChoices()
		{
			var json = PlayerPrefs.GetString(SAVE_KEY, null);

			if (json == null)
			{
				Debug.Log("Save was null.");
				return;
			}

			var serialized = JsonUtility.FromJson<SerializedChoices>(json);
			if (serialized?.choices == null)
			{
				Debug.Log("Save when parsed from json was null.");
				return;
			}

			var loadedChoices = new Dictionary<PlayerChoice, int>();
			foreach (var serializedChoice in serialized.choices)
			{
				if (Enum.TryParse(serializedChoice.choice, out PlayerChoice choice))
				{
					Debug.Log("Loaded choice: " + choice + " " + serializedChoice.choiceValue);
					loadedChoices[choice] = serializedChoice.choiceValue;
				}
				else
				{
					Debug.LogWarning("Encountered unknown choice: " + serializedChoice.choice);
				}
			}

			foreach (var loadedChoice in loadedChoices)
			{
				this.choicesPlayerHasMade[loadedChoice.Key] = loadedChoice.Value;
			}
		}

		[Serializable]
		class SerializedChoices
		{
			public List<SerializedChoice> choices = new List<SerializedChoice>();

			[Serializable]
			public class SerializedChoice
			{
				public string choice;
				public int choiceValue;
			}
		}
	}
}