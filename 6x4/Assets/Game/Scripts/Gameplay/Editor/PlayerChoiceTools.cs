namespace Game.Scripts.Gameplay.Editor
{
	using UnityEditor;
	using UnityEngine;

	public static class PlayerChoiceTools
	{
		[MenuItem("6x4/Reset Player Choices")]
		public static void ResetPlayerChoices()
		{
			PlayerPrefs.DeleteKey(PlayerChoiceService.SAVE_KEY);
		}
	}
}