using System;

namespace WaterPipes
{
	internal class SourceCell : Cell
	{
		public static string sourceName = "SourceCell";

		public SourceCell() : base(false, 'S', true, ConsoleColor.Yellow, sourceName)
		{
		}
	}
}