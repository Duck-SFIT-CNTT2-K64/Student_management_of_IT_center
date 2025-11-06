using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Student_manager.UI
{
    internal static class TextBoxExtensions
    {
        private const int EM_SETCUEBANNER = 0x1501;

        // SendMessageW - Unicode
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, string lParam);

        /// <summary>
        /// Set native cue banner (placeholder) on a TextBox for .NET Framework WinForms.
        /// Usage: myTextBox.SetPlaceholder("Enter title...");
        /// </summary>
        public static void SetPlaceholder(this TextBox textBox, string placeholder)
        {
            if (textBox == null) return;
            try
            {
                // wParam = (BOOL) show cue even when control has focus -> true (1) or false (0)
                SendMessage(textBox.Handle, EM_SETCUEBANNER, (IntPtr)1, placeholder ?? string.Empty);
            }
            catch
            {
                // ignore on failure (rare)
            }
        }
    }
}