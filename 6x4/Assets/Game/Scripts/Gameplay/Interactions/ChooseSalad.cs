namespace Game.Scripts.Gameplay
{
	using System.Collections;
	using UnityEngine;
	using Zenject;

	public class ChooseSalad : Interaction
	{
		[SerializeField] GameObject salad = default;
		[SerializeField] GameObject pizza = default;
        [SerializeField] GameObject potatoes = default;
        [Inject] PlayerMover playerMover = default;
		[Inject] IPlayerChoiceService playerChoiceService = default;

		void Start()
		{

		}

		public override IEnumerator RunInteraction()
		{
			yield return this.playerMover.MoveToPosition(this.transform.position);

			this.setLunch(PlayerChoiceValues.LUNCH_SALAD);
		}

		void setLunch(int lunch)
		{
			this.salad.SetActive(lunch != PlayerChoiceValues.LUNCH_SALAD);
			this.pizza.SetActive(lunch != PlayerChoiceValues.LUNCH_PIZZA);
            this.potatoes.SetActive(lunch != PlayerChoiceValues.LUNCH_POTATOES);
		}
	}
}