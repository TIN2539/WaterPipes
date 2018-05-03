using System;

namespace WaterPipes
{
	internal class RightCommand : Command
	{
		private Game game;

		public RightCommand(Game game) : base(ConsoleKey.RightArrow)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			if (game.UserCursor.CurrentX < game.UserField.Column)
			{
				Console.SetCursorPosition(game.UserCursor.IncrementX(), game.UserCursor.CurrentY);
			}
			return base.Execute();
		}
	}
}