using System;

namespace WaterPipes
{
	internal class EnterCommand : Command
	{
		private Game game;

		public EnterCommand(Game game) : base(ConsoleKey.Enter)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			int indexY = game.GetCursor().GetCurrentY() - game.GetField().GetTopMost();
			int indexX = game.GetCursor().GetCurrentX() - game.GetField().GetLeftMost();
			if (game.CheckNeighbors(indexX, indexY) && game.GetField().GetCells()[indexY, indexX].GetName() != SourceCell.sourceName)
			{
				game.GetField().GetCells()[indexY, indexX] = new PipeCell();
			}
			return base.Execute();
		}
	}
}