using SixTimesFour.Core;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Input
{
    public class MouseClickListener : MonoBehaviour
    {
        [Inject(Id = Cameras.Main)] private Camera mainWorldCamera = default;
        [Inject] private IInputService inputService = default;

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                inputService.SignalPress(mainWorldCamera.ScreenToWorldPoint(UnityEngine.Input.mousePosition));
            }
        }
    }
}