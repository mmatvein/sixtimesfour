namespace Game.Scripts.SceneSetups
{
	using UI;
	using Zenject;

	public class MorningSceneSetup : UnityEngine.MonoBehaviour
	{
		[Inject] SpeechBubble speechBubble = default; 
		
		void Start()
		{
#pragma warning disable 4014
			this.speechBubble.ShowAsync("Hello there", "Well hello", "I hate you");
#pragma warning restore 4014
		}
	}
}