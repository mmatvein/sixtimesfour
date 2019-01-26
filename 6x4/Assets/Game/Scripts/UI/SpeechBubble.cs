namespace Game.Scripts.UI
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using TMPro;
	using UnityEngine;

	public class SpeechBubble : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI speechText = default;
		[SerializeField] SpeechBubbleButton buttonPrefab = default;

		List<SpeechBubbleButton> spawnedButtons;

		public async Task<int> ShowAsync(string speech, params string[] buttonTexts)
		{
			this.gameObject.SetActive(true);
			
			this.speechText.text = speech;

			this.spawnedButtons = new List<SpeechBubbleButton>();

			var chosenButtonIndex = -1;
			var buttonIndex = 0;
			foreach (var buttonText in buttonTexts)
			{
				var button = Instantiate(this.buttonPrefab, this.transform);
				button.Setup(buttonText, () => chosenButtonIndex = buttonIndex);
				this.spawnedButtons.Add(button);
				buttonIndex++;
			}

			while (chosenButtonIndex == -1)
			{
				await Task.Yield();
			}
			
			this.gameObject.SetActive(false);
			
			return chosenButtonIndex;
		}
	}
}