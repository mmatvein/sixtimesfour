namespace Game.Scripts.Input
{
	using Gameplay;
	using UnityEngine;
	using Zenject;

	public class InputProcessor : MonoBehaviour
    {
        [Inject] IInputService inputService = default;
        [Inject] PlayerMover playerMover = default;

        void OnEnable()
        {
			this.inputService.OnPressHappened += this.HandleInput;
        }

        void OnDisable()
        {
			this.inputService.OnPressHappened -= this.HandleInput;
        }

        void HandleInput(Vector3 worldCoordinates)
        {
            var pos = worldCoordinates;
            pos.z = 0;
			this.StopAllCoroutines();
			this.StartCoroutine(this.playerMover.MoveToPosition(pos));
        }
    }
}