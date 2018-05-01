using System;

namespace WaterPipes
{
	internal class SCommand : Command
	{
		private Game game;

		public SCommand(Game game) : base(ConsoleKey.S)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			game.GetField().GetCells()[game.GetCursor().GetCurrentY() - game.GetField().GetTopMost(), game.GetCursor().GetCurrentX()
			- game.GetField().GetLeftMost()] = new SourceCell();
			return base.Execute();
		}
	}
}