using System.Windows.Forms;

namespace StadiumMS.Helpers
{
    public static class Msg
    {
        public static void Info(string text, string title = "Stadium Management")
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warn(string text, string title = "Stadium Management")
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Error(string text, string title = "Error")
        {
            MessageBox.Show(text, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static bool Confirm(string text, string title = "Confirm")
        {
            return MessageBox.Show(text, title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
