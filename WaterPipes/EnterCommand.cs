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
			int indexY = game.UserCursor.CurrentY - game.UserField.TopMost;
			int indexX = game.UserCursor.CurrentX - game.UserField.LeftMost;
			if (game.CheckNeighbors(indexX, indexY) && game.UserField.Cells[indexY, indexX].Name != SourceCell.sourceName)
			{
				game.UserField.Cells[indexY, indexX] = new PipeCell();
			}
			return base.Execute();
		}
	}
}