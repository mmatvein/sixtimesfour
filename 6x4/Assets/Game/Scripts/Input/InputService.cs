using UnityEngine;

namespace Game.Scripts.Input
{
    public delegate void WorldCoordinatesCallback(Vector3 worldCoordinates);
    
    public interface IInputService
    {
        event WorldCoordinatesCallback OnPressHappened;
        
        void SignalPress(Vector3 worldCoordinates);
    }
    
    public class InputService : IInputService
    {
        public event WorldCoordinatesCallback OnPressHappened;
        public void SignalPress(Vector3 worldCoordinates)
        {
            Debug.Log("Press happened");
            OnPressHappened?.Invoke(worldCoordinates);
        }
    }
}