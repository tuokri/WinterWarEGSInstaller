using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WinterWarEGSInstaller.Components
{
    internal sealed class ReadOnlyTextBox : TextBox
    {
        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        public ReadOnlyTextBox()
        {
            this.ReadOnly = true;
            this.GotFocus += TextBoxGotFocus;
            this.Cursor = Cursors.IBeam;
            this.Multiline = true;
            this.ScrollBars = ScrollBars.Vertical;
        }

        private void TextBoxGotFocus(object sender, EventArgs args)
        {
            HideCaret(this.Handle);
        }
    }
}
