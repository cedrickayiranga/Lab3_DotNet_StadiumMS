using System;
using System.Windows.Forms;
using StadiumMS.Controllers;
using StadiumMS.Helpers;
using StadiumMS.Views;

namespace StadiumMS
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string error;
            if (!Db.TestConnection(out error))
            {
                Msg.Error("Cannot connect to the database.\n\n" +
                          "1) Start MySQL in the XAMPP Control Panel.\n" +
                          "2) Import Database/stadium_db.sql in phpMyAdmin.\n\n" +
                          "Details: " + error, "Database connection");
                return;
            }

            UserController.EnsureDefaultAdmin();

            LoginForm login = new LoginForm();
            login.FormClosed += Nav.ExitApp;
            login.Show();
            Application.Run();
        }
    }
}
