using System;

namespace WaterPipes
{
	internal abstract class ICommand
	{
		public abstract bool CanExecute(ConsoleKey key);

		public abstract bool Execute();
	}
}