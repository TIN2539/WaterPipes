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
			int indexY = game.UserCursor.CurrentY - game.UserField.TopMost;
			int indexX = game.UserCursor.CurrentX - game.UserField.LeftMost;
			game.UserField.Cells[indexY, indexX].IsChecked = true;
			if (game.CheckIsPosibleDelete(indexX, indexY))
			{
				game.UserField.Cells[indexY, indexX] = new Cell();
			}
			return base.Execute();
		}
	}
}