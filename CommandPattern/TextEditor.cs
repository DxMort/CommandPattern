using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
{
    public class TextEditor
    {
        public string Text { get; private set; } = "Егор: ";

        public void InsertText(string text, int position)
        {
            if (position < 0 || position > Text.Length)
                position = Text.Length;
            Text = Text.Insert(position, text);
        }
        public void DeleteText(int position, int length)
        {
            if (position < 0 || position >= Text.Length || length <= 0)
                return;

            int end = Math.Min(position + length, Text.Length);
            Text = Text.Remove(position, end - position);
        }
    }
}