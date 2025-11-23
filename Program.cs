using LibraryTeamWinFormApp.Forms.Auth;
using LibraryTeamWinFormApp.Forms.Shared;
using System;
using System.Windows.Forms;

namespace LibraryTeamWinFormApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}