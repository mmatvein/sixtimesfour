namespace Game.Scripts.Input
{
	using JetBrains.Annotations;
	using UnityEngine;

	public delegate void WorldCoordinatesCallback(Vector3 worldCoordinates);
    
    public interface IInputService
    {
        event WorldCoordinatesCallback OnPressHappened;
        
        void SignalPress(Vector3 worldCoordinates);
    }
    
    [UsedImplicitly]
	public class InputService : IInputService
    {
        public event WorldCoordinatesCallback OnPressHappened;
        public void SignalPress(Vector3 worldCoordinates)
        {
            Debug.Log("Press happened");
			this.OnPressHappened?.Invoke(worldCoordinates);
        }
    }
}