namespace Game.Scripts.Contexts
{
	using System.Collections.Generic;
	using System.Linq;
	using Gameplay;
	using UnityEngine;
	using Zenject;

	public class DialogItemInstaller : MonoInstaller
	{
		[SerializeField] List<DialogItem> dialogItems = default;

		[Inject] IPlayerChoiceService playerChoiceService = default;

		public override void InstallBindings()
		{
			this.SetupDialog();
		}

		void SetupDialog()
		{
			var validDialogItems = this.dialogItems.FilterForPreconditions(
				this.playerChoiceService,
				item => item.preconditions);

			var firstValidItem = validDialogItems.FirstOrDefault();

			if (firstValidItem != null)
			{
				this.Container.BindInstance(firstValidItem);
			}
			else
			{
				Debug.LogWarning("No dialog item is valid based on preconditions!");
			}
		}
	}
}