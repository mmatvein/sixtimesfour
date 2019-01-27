namespace Game.Scripts.UI
{
	using UnityEngine;

	public class Fader : MonoBehaviour
	{
		[SerializeField] Animator animator = default;
		static readonly int SHOW = Animator.StringToHash("Show");
		static readonly int HIDE = Animator.StringToHash("Hide");

		public void ShowFade()
		{
			Debug.Log("Showing Fade");
			this.animator.SetTrigger(SHOW);
		}

		public void HideFade()
		{
			Debug.Log("Hiding Fade");
			this.animator.SetTrigger(HIDE);
		}
	}
}