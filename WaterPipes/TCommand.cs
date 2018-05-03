using System;

namespace WaterPipes
{
	internal abstract class TCommand
	{
		public abstract bool CanExecute(ConsoleKey key);

		public abstract bool Execute();
	}
}