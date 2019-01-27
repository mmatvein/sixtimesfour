namespace Game.Scripts.UI
{
	using TMPro;
	using UnityEngine;

	public class Fader : MonoBehaviour
	{
		[SerializeField] Animator animator = default;
		[SerializeField] TextMeshPro interludeText = default;
		static readonly int SHOW = Animator.StringToHash("Show");
		static readonly int HIDE = Animator.StringToHash("Hide");

		public void ShowFade(string text)
		{
			Debug.Log("Showing Fade");
			this.animator.SetTrigger(SHOW);

			this.interludeText.text = text;
		}

		public void HideFade()
		{
			Debug.Log("Hiding Fade");
			this.animator.SetTrigger(HIDE);
		}
	}
}