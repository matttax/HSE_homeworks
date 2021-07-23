using System.Collections.Generic;
using System.Windows.Forms;

namespace texte
{
    class RicherTextBox : RichTextBox
    {
        // Undo stack.
        public Stack<string> UndoChanges = new Stack<string>();
        // Redo stack.
        public Stack<string> RedoChanges = new Stack<string>();
        // Text before undo/redo changes.
        public string DefaultText;
        
        // File's path.
        public string Path { get; set; }

        // Autosave parameters.
        public string Autosave;
        public Timer AutosaveTimer;

        // Logging parameters.
        public string Logging;
        public string SecretFolder;
        public Timer LoggingTimer;

    }
}
