using GestorEmpleado.DAL;
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
    public partial class ListaEmpleados : Form
    {
        public ListaEmpleados()
        {
            InitializeComponent();
        }

        private void ListaEmpleados_Load(object sender, EventArgs e)
        {
            CargarDataGridView();
        }

        public void CargarDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = DAL_Empleados.GetList();
            dataGridView1.Columns["IdEmpleado"].Visible = false;
        }
    }
}
