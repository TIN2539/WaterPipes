using System;

namespace WaterPipes
{
	internal class LeftCommand : Command
	{
		private Game game;

		public LeftCommand(Game game) : base(ConsoleKey.LeftArrow)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			if (game.UserCursor.CurrentX > game.UserField.LeftMost)
			{
				Console.SetCursorPosition(game.UserCursor.DecrementX(), game.UserCursor.CurrentY);
			}
			return base.Execute();
		}
	}
}