namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using System.Linq;
	using TMPro;
	using UnityEngine;
	using Zenject;

	public class Epilogue : MonoBehaviour
	{
		[SerializeField] float waitBeforeKill = default;
		[SerializeField] TextMeshProUGUI epilogueText = default;
		[Inject] DialogItem[] dialogItems = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;
		
		IEnumerator Start()
		{
			var dialogItemToShow = this.dialogItems.FilterForPreconditions(
				this.playerChoiceService,
				item => item.preconditions).FirstOrDefault();
			
			if (dialogItemToShow != null)
			{
				this.epilogueText.text = dialogItemToShow.speech;
			}

			yield return new WaitForSeconds(this.waitBeforeKill);

			while (!Input.GetMouseButtonUp(0) && Input.touchCount == 0)
			{
				yield return null;
			}

			Debug.Log("Quitting");
			Application.Quit();
		}
	}
}
