using System.Runtime.InteropServices;
using System.Windows;

namespace WebViewTest
{
    [ComVisible(true)]
    public sealed class HtmlInterop
    {
        public void ShowMessageBox(string value)
        {
            MessageBox.Show(value);
        }
    }
}