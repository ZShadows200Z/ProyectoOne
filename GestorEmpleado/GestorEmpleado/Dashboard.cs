using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorEmpleado
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }
        //Función que abre formularios unicos
        private void AbrirFormulario<T>() where T : Form, new()
        {
            Form formulario = Application.OpenForms
                .OfType<T>()
                .FirstOrDefault();
            if(formulario == null)
            {
                formulario = new T();
                formulario.Show();
            }
            else
            {
                formulario.BringToFront();

                if (formulario.WindowState == FormWindowState.Minimized)
                    formulario.WindowState = FormWindowState.Normal;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AbrirFormulario<Editar>();
        }
        //Ingresar Empleados
        private void button2_Click(object sender, EventArgs e)
        {
            AbrirFormulario<INGEMP>();
        }
        //Configuracion
        private void button6_Click(object sender, EventArgs e)
        {

        }
    }
}
