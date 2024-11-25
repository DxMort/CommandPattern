using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class DeleteTextCommand : ICommand
    {
        private readonly TextEditor _editor;
        private readonly int _position;
        private readonly int _length;
        private string _deletedText;

        public DeleteTextCommand(TextEditor editor, int position, int length)
        {
            _editor = editor;
            _position = position;
            _length = length;
        }

        public void Execute()
        {
            if (_position < 0 || _position >= _editor.Text.Length || _length <= 0)
                return;
            Console.Write("Удаление: ");
            int end = Math.Min(_position + _length, _editor.Text.Length);
            _deletedText = _editor.Text.Substring(_position, end - _position);
            _editor.DeleteText(_position, _length);
        }
        public void Undo()
        {
            if (_deletedText != null)
            {
                _editor.InsertText(_deletedText, _position);
            }
        }
    }
}