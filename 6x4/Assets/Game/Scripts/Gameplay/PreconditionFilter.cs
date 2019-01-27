namespace Game.Scripts.Gameplay
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public static class PreconditionFilter
	{
		public static IEnumerable<T> FilterForPreconditions<T>(
			this IEnumerable<T> enumerable,
			IPlayerChoiceService playerChoiceService,
			Func<T, List<DialogItem.Precondition>> preconditionListGetter)
		{
			return enumerable.Where(
				item =>
				{
					foreach (var precondition in preconditionListGetter(item))
					{
						if (playerChoiceService.GetChoice(
								precondition.choice,
								precondition.assumedChoiceValue) !=
							precondition.choiceValue)
						{
							return false;
						}
					}

					return true;
				});
		}
	}
}