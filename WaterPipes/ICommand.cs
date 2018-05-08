using System;

namespace WaterPipes
{
	internal interface ICommand
	{
		bool CanExecute(ConsoleKey key);

		bool Execute();
	}
}