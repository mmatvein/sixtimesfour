namespace Game.Scripts.Contexts
{
	using Gameplay;
	using UnityEngine;
	using Zenject;

	public class InteractionInstaller : MonoInstaller
	{
		[SerializeField] Interaction[] interactions = default;

		public override void InstallBindings()
		{
			foreach (var interaction in this.interactions)
			{
				this.Container.BindInstances(interaction);
			}
		}
	}
}