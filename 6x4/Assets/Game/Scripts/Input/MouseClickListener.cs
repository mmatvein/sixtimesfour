namespace Game.Scripts.Input
{
	using SixTimesFour.Core;
	using UnityEngine;
	using Zenject;

	public class MouseClickListener : MonoBehaviour
    {
        [Inject(Id = Cameras.Main)] Camera mainWorldCamera = default;
        [Inject] IInputService inputService = default;

		void Update()
        {
            if (Input.GetMouseButtonUp(0))
            {
				this.inputService.SignalPress(this.mainWorldCamera.ScreenToWorldPoint(Input.mousePosition));
            }
        }
    }
}