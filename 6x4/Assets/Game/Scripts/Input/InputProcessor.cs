namespace Game.Scripts.Input
{
	using System.Numerics;
	using Gameplay;
	using UnityEngine;
	using Zenject;
	using Vector3 = UnityEngine.Vector3;

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

			var interaction = RaycastToGetInteraction(worldCoordinates);

			this.StopAllCoroutines();
			this.StartCoroutine(
				interaction != null ? interaction.RunInteraction() : this.playerMover.MoveToPosition(pos));
		}

		static Interaction RaycastToGetInteraction(Vector3 worldCoordinates)
		{
			if (Physics.Raycast(
					worldCoordinates,
					Vector3.forward,
					out var hit,
					1000,
					LayerMask.GetMask("Interactions"))
				)
			{
				Debug.Log("Raycast hit! " + hit.collider.gameObject.name);
				return hit.collider.gameObject.GetComponent<Interaction>();
			}

			return null;
		}
	}
}