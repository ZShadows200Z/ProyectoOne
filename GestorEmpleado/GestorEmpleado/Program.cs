using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestorEmpleado
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Form1 login = new Form1();//Creamos un Formulario Login para que se registren los usuario
            if(login.ShowDialog() == DialogResult.OK)//Consultamos si el login fue exitoso
            {
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Dashboard());//Si fue exitoso abrimos el menú y el login se cierra
            }

        }
    }
}
