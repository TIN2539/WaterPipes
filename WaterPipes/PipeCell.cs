using System;

namespace WaterPipes
{
	internal class PipeCell : Cell
	{
		public static string pipeName = "PipeCell";

		public PipeCell() : base(false, 'O', false, ConsoleColor.White, pipeName)
		{
		}
	}
}