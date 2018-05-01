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
			if (game.GetCursor().GetCurrentY() > game.GetField().GetTopMost())
			{
				Console.SetCursorPosition(game.GetCursor().GetCurrentX(), game.GetCursor().DecrementY());
			}
			return base.Execute();
		}
	}
}