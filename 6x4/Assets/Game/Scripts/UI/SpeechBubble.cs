namespace Game.Scripts.UI
{
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Gameplay;
	using TMPro;
	using UnityEngine;

	public class SpeechBubble : MonoBehaviour
	{
		[SerializeField] TextMeshProUGUI speechText = default;
		[SerializeField] SpeechBubbleButton buttonPrefab = default;

		List<SpeechBubbleButton> spawnedButtons = new List<SpeechBubbleButton>();
		
		void DestroySpawnedButtons()
        {
            foreach (var button in this.spawnedButtons)
            {
                Destroy(button.gameObject);
            }

			this.spawnedButtons.Clear();
		}

		public async Task<DialogItem.Button> ShowAsync(string speech, params DialogItem.Button[] buttons)
		{
			this.DestroySpawnedButtons();

			if (buttons.Length == 0)
			{
				buttons = new [] { new DialogItem.Button { text = "Continue", choice = PlayerChoice.Undefined }};
			}

			this.speechText.text = speech;

			DialogItem.Button chosenButton = null;
			foreach (var button in buttons)
			{
				var buttonInstance = Instantiate(this.buttonPrefab, this.transform);
				buttonInstance.Setup(button, () => chosenButton = button);
				this.spawnedButtons.Add(buttonInstance);
			}
			
			this.gameObject.SetActive(true);

			while (chosenButton == null)
			{
				await Task.Yield();
			}
			
			this.gameObject.SetActive(false);
			
			return chosenButton;
		}
	}
}