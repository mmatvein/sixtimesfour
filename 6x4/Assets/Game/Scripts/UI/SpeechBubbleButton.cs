namespace Game.Scripts.UI
{
	using Gameplay;
	using TMPro;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.UI;

	public class SpeechBubbleButton : MonoBehaviour
	{
		[SerializeField] Button button = default;
		[SerializeField] TextMeshProUGUI buttonText = default;

		public void Setup(DialogItem.Button buttonData, UnityAction onClick)
		{
			this.buttonText.text = buttonData.text;
			this.button.onClick.AddListener(onClick);
		}
	}
}