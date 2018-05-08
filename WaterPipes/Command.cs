using System;

namespace WaterPipes
{
	internal class Command : ICommand
	{
		private ConsoleKey key;

		public Command(ConsoleKey key)
		{
			this.key = key;
		}

		public virtual bool CanExecute(ConsoleKey key)
		{
			return this.key == key;
		}

		public virtual bool Execute()
		{
			return key == ConsoleKey.Spacebar;
		}
	}
}