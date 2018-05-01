using System;

namespace WaterPipes
{
	internal class Step
	{
		private int numberOfSteps;

		public Step()
		{
			numberOfSteps = 0;
		}

		public int GetNumberOfStep()
		{
			return numberOfSteps;
		}

		public void Paint()
		{
			Console.SetCursorPosition(0, 0);
			Console.Write("Step: ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(numberOfSteps);
			Console.ResetColor();
		}

		public void Update()
		{
			numberOfSteps++;
		}
	}
}