namespace Game.Scripts.UI
{
	using TMPro;
	using UnityEngine;
	using UnityEngine.Events;
	using UnityEngine.UI;

	public class SpeechBubbleButton : MonoBehaviour
	{
		[SerializeField] Button button = default;
		[SerializeField] TextMeshProUGUI buttonText = default;

		public void Setup(string text, UnityAction onClick)
		{
			this.buttonText.text = text;
			this.button.onClick.AddListener(onClick);
		}
	}
}