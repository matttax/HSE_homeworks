using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.ExceptionServices;


namespace texte
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        [HandleProcessCorruptedStateExceptions]
        static void Main()
        {
            // А почему бы и нет?
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new TextPad());
            }
            catch (Exception)
            {
                MessageBox.Show("Something's gone wrong");
                Application.Run(new TextPad());
            }
        }
    }
}
