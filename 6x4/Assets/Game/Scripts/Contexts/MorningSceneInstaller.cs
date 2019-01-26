namespace Game.Scripts.Contexts
{
	using Gameplay;
	using UnityEngine;
	using Zenject;

	public class MorningSceneInstaller : MonoInstaller
	{
		[SerializeField] BedInteraction bedInteraction = default;
		[SerializeField] DialogItem bedUnmadeDialog = default;
		[SerializeField] DialogItem bedMadeDialog = default;

		[Inject] IPlayerChoiceService playerChoiceService = default;
		
		public override void InstallBindings()
		{
			this.Container.BindInstances(this.bedInteraction);

			this.SetupDialog();
		}

		void SetupDialog()
		{
			var bedMadeChoice = this.playerChoiceService.GetChoice(PlayerChoice.MadeBed, PlayerChoiceValues.BED_UNMADE);
			this.Container.BindInstance(
				bedMadeChoice == PlayerChoiceValues.BED_UNMADE ? 
					this.bedUnmadeDialog : 
					this.bedMadeDialog);
		}
	}
}