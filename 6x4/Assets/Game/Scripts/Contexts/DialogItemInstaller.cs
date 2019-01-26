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
			var validDialogItems = this.dialogItems.Where(
				item =>
				{
					foreach (var precondition in item.preconditions)
					{
						if (this.playerChoiceService.GetChoice(
								precondition.choice,
								precondition.assumedChoiceValue) !=
							precondition.choiceValue)
						{
							return false;
						}
					}

					return true;
				});

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