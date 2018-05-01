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
			if (game.GetCursor().GetCurrentY() <= game.GetField().GetRow())
			{
				Console.SetCursorPosition(game.GetCursor().GetCurrentX(), game.GetCursor().IncrementY());
			}
			return base.Execute();
		}
	}
}