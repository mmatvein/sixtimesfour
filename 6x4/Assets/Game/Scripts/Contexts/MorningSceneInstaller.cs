namespace Game.Scripts.Contexts
{
	using System.Collections.Generic;
	using System.Linq;
	using Gameplay;
	using UnityEngine;
	using Zenject;

	public class MorningSceneInstaller : MonoInstaller
	{
		[SerializeField] BedInteraction bedInteraction = default;
		
		
		public override void InstallBindings()
		{
			this.Container.BindInstances(this.bedInteraction);
		}
	}
}