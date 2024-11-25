using CommandPattern;

class Program
{
    static void Main(string[] args)
    {
        TextEditor editor = new TextEditor();
        CommandHistory commandHistory = new CommandHistory();

        Console.WriteLine("Исходный текст: " + editor.Text);

        var insertCommand1 = new InsertTextCommand(editor, "Я пердоле", editor.Text.Length);
        commandHistory.ExecuteCommand(insertCommand1);
        Console.WriteLine($"«{editor.Text}»");

        var insertCommand2 = new InsertTextCommand(editor, ", бобр курва!", editor.Text.Length);
        commandHistory.ExecuteCommand(insertCommand2);
        Console.WriteLine($"«{editor.Text}»");

        var deleteCommand = new DeleteTextCommand(editor, 15, 12);
        commandHistory.ExecuteCommand(deleteCommand);
        Console.WriteLine($"«{editor.Text}");

        commandHistory.UndoLastCommand();
        Console.WriteLine($"«{editor.Text}»");

        commandHistory.UndoLastCommand();
        Console.WriteLine($"«{editor.Text}");

        commandHistory.UndoLastCommand();
        Console.WriteLine($"«{editor.Text}");
    }
}