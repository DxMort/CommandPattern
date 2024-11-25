using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class InsertTextCommand : ICommand
    {
        private readonly TextEditor _editor;
        private readonly string _textToInsert;
        private readonly int _position;
        private int _actualPosition;

        public InsertTextCommand(TextEditor editor, string text, int position)
        {
            _editor = editor;
            _textToInsert = text;
            _position = position;
        }
        public void Execute()
        {
            Console.Write("Вставка: ");
            _actualPosition = Math.Min(_position, _editor.Text.Length);
            _editor.InsertText(_textToInsert, _actualPosition);
        }
        public void Undo()
        {
            _editor.DeleteText(_actualPosition, _textToInsert.Length);
        }
    }
}