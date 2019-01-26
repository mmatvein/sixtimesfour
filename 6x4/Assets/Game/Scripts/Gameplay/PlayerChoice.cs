namespace Game.Scripts.Gameplay
{
	public enum PlayerChoice
	{
		Undefined = -1,
		MadeBed,
	}

	public static class PlayerChoiceValues
	{
		public const int BED_MADE = 0;
		public const int BED_UNMADE = 1;

        public const int CUPBOARD_UPPER_OPEN = 0;
        public const int CUPBOARD_LOWER_OPEN = 1;

        public const int BEGGAR_IGNORE = 0;
        public const int BEGGAR_DECLINE = 1;
        public const int BEGGAR_GIVECOIN = 2;

        public const int FRIEND_DEPRESSED = 0;
        public const int FRIEND_IWANTOUT = 1;

        public const int COMPUTER_WORK = 0;
        public const int COMPUTER_SOME = 1;

        public const int COWORKER_NEUTRAL = 0;
        public const int COWORKER_SUPPORT = 1;

        public const int LUNCH_POTATOES = 0;
        public const int LUNCH_SALAD = 1;
        public const int LUNCH_PIZZA = 2;

        public const int BOSS_SUBMIT = 0;
        public const int BOSS_DEMAND = 1;


	}
}