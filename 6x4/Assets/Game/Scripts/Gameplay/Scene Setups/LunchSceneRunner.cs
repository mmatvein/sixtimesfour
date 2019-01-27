namespace Game.Scripts.Gameplay.SceneSetups
{
	using System.Collections;
	using TMPro;
	using UnityEngine;
	using Zenject;

	public class LunchSceneRunner : SceneRunner
	{
		[SerializeField] GameObject salad = default;
		[SerializeField] GameObject pizza = default;
		[SerializeField] GameObject potatoes = default;
		[Inject] PlayerMover playerMover = default;
		
		protected override IEnumerator HandleResult(PlayerChoice choice, int choiceValue)
		{
			if (choice == PlayerChoice.Lunch)
			{
				var lunchPosition = this.SetLunch(choiceValue);

				yield return this.playerMover.MoveToPosition(lunchPosition);
			}

			yield return new WaitForSeconds(1.0f);
		}
		
		Vector3 SetLunch(int lunch)
		{
			this.salad.SetActive(lunch == PlayerChoiceValues.LUNCH_SALAD);
			this.pizza.SetActive(lunch == PlayerChoiceValues.LUNCH_PIZZA);
			this.potatoes.SetActive(lunch == PlayerChoiceValues.LUNCH_POTATOES);

			if (this.salad.activeSelf)
			{
				return this.salad.transform.position;
			}
			else if (this.pizza.activeSelf)
			{
				return this.pizza.transform.position;
			}
			else
			{
				return this.potatoes.transform.position;
			}
		}
	}
}