using System;

namespace WaterPipes
{
	internal class UpCommand : Command
	{
		private Game game;

		public UpCommand(Game game) : base(ConsoleKey.UpArrow)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			if (game.UserCursor.CurrentY > game.UserField.TopMost)
			{
				Console.SetCursorPosition(game.UserCursor.CurrentX, game.UserCursor.DecrementY());
			}
			return base.Execute();
		}
	}
}