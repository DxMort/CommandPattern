using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class CommandHistory
    {
        private readonly Stack<ICommand> _commandHistory = new();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _commandHistory.Push(command);
        }

        public void UndoLastCommand()
        {
            if (_commandHistory.Count > 0)
            {
                ICommand command = _commandHistory.Pop();
                Console.Write("Отмена:   ");
                command.Undo();
            }
            else
            {
                Console.WriteLine("Нет команд для отмены.");
            }
        }
    }
}