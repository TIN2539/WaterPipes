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
			if (game.GetCursor().GetCurrentX() < game.GetField().GetColumn())
			{
				Console.SetCursorPosition(game.GetCursor().IncrementX(), game.GetCursor().GetCurrentY());
			}
			return base.Execute();
		}
	}
}