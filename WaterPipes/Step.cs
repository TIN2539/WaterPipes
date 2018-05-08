﻿using System;

namespace WaterPipes
{
	internal class Step
	{
		public Step()
		{
			NumberOfStep = 0;
		}

		public int NumberOfStep { get; internal set; }

		public void Paint()
		{
			Console.SetCursorPosition(0, 0);
			Console.Write("Step: ");
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine(NumberOfStep);
			Console.ResetColor();
		}

		public void Update()
		{
			NumberOfStep++;
		}
	}
}