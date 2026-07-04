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
    public partial class INGEMP : Form
    {
        public INGEMP()
        {
            InitializeComponent();
        }
        //Función que inicializa metodos al abrirse el formulario
        private void INGEMP_Load(object sender, EventArgs e)
        {
            CargarComboCargos();
            CargarComboSucursales();
        }
        //Metodo para cargar combobox con información de la base de datos
        private void CargarComboCargos()
        {
            DataTable dt = DAL_Cargos.GetList();

            DataRow filaInicial = dt.NewRow();
            filaInicial["IdCargo"] = 0;
            filaInicial["Nombre"] = "Cargos";
            dt.Rows.InsertAt(filaInicial, 0);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "IdCargo";
        }
        private void CargarComboSucursales()
        {
            DataTable dt = DAL_Sucursales.GetList();

            DataRow filaInicial = dt.NewRow();
            filaInicial["IdSucursal"] = 0;
            filaInicial["Nombre"] = "Sucursales";
            dt.Rows.InsertAt(filaInicial, 0);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Nombre";
            comboBox2.ValueMember = "IdSucursal";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //Boton Guardar
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
