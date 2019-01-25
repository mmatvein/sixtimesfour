namespace Game.Scripts.Input
{
	using SixTimesFour.Core;
	using UnityEngine;
	using Zenject;

	public class TouchListener : MonoBehaviour
	{
		[Inject(Id = Cameras.Main)] Camera mainWorldCamera = default;
		[Inject] IInputService inputService = default;

		void Update()
		{
			if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended)
			{
				this.inputService.SignalPress(this.mainWorldCamera.ScreenToWorldPoint(Input.touches[0].position));
			}
		}
	}
}