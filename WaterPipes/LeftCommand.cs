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
			if (game.GetCursor().GetCurrentX() > game.GetField().GetLeftMost())
			{
				Console.SetCursorPosition(game.GetCursor().DecrementX(), game.GetCursor().GetCurrentY());
			}
			return base.Execute();
		}
	}
}