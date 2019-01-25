using Game.Scripts.Gameplay;
using UnityEngine;
using Zenject;

namespace Game.Scripts.Input
{
    public class InputProcessor : MonoBehaviour
    {
        [Inject] private IInputService inputService = default;
        [Inject] private PlayerMover playerMover = default;

        void OnEnable()
        {
            inputService.OnPressHappened += HandleInput;
        }

        void OnDisable()
        {
            inputService.OnPressHappened -= HandleInput;
        }

        void HandleInput(Vector3 worldCoordinates)
        {
            var pos = worldCoordinates;
            pos.z = 0;
            StopAllCoroutines();
            StartCoroutine(playerMover.MoveToPosition(pos));
        }
    }
}