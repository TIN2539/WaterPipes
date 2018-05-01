using System;

namespace WaterPipes
{
	class DeleteCommand : Command
	{
		private Game game;

		public DeleteCommand(Game game) : base(ConsoleKey.Delete)
		{
			this.game = game;
		}

		public override bool Execute()
		{
			int indexY = game.GetCursor().GetCurrentY() - game.GetField().GetTopMost();
			int indexX = game.GetCursor().GetCurrentX() - game.GetField().GetLeftMost();
			game.GetField().GetCells()[indexY, indexX].SetIsChecked();
			if (game.CheckIsPosibleDelete(indexX, indexY))
			{
				game.GetField().GetCells()[indexY, indexX] = new Cell();
			}
			return base.Execute();
		}
	}
}