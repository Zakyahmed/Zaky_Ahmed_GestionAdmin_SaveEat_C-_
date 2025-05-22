using System;
using System.Windows.Forms;

namespace GestionAdmin_SaveEat_C_
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmConnexion());
        }
    }
}