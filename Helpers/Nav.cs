using System;
using System.Windows.Forms;

namespace StadiumMS.Helpers
{
    public static class Nav
    {
        public static void Go(Form current, Form next)
        {
            next.FormClosed += ExitApp;
            next.Show();
            current.FormClosed -= ExitApp;
            current.Close();
        }

        public static void ExitApp(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
