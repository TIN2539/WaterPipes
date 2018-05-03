using System;

namespace WaterPipes
{
	internal class DownCommand : Command
	{
		private Game game;

		public DownCommand(Game game) : base(ConsoleKey.DownArrow)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			if (game.UserCursor.CurrentY <= game.UserField.Row)
			{
				Console.SetCursorPosition(game.UserCursor.CurrentX, game.UserCursor.IncrementY());
			}
			return base.Execute();
		}
	}
}