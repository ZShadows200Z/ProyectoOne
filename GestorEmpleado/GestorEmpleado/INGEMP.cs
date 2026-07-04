using GestorEmpleado.DAL;
using GestorEmpleado.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
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
        //Validaciones
        private bool ValidateNombreNull()
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Agregue un Nombre para el empleado");
                return false;
            }
            return true;
        }
        private bool ValidateRowCombo(ComboBox sender)
        {
            int idSeleccionado = Convert.ToInt32(sender.SelectedValue);

            // Validar que no sea la opción inicial
            if (idSeleccionado == 0)
            {
                MessageBox.Show("Recibió encabezados, por favor, seleccione una opción correcta de la cada de elección");
                return false;
            }
            return true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
        //Boton Guardar
        private void button1_Click(object sender, EventArgs e)
        {
            if(ValidateNombreNull() && ValidateRowCombo(comboBox1) && ValidateRowCombo(comboBox2))
            {
                try
                {
                    Empleados empleados = new Empleados();
                    empleados.Nombre = Regex.Replace(textBox1.Text.Trim(), "[^a-zA-Z0-9 ]", "");
                    empleados.IdCargo = Convert.ToInt32(comboBox1.SelectedValue);
                    empleados.IdSucursal = Convert.ToInt32(comboBox2.SelectedValue);
                    empleados.FechaIngreso = dateTimePicker1.Value;
                    empleados.FechaExoneracion = dateTimePicker2.Value;
                    empleados.IdMotivoExoneracion = 1;//1 significa NoExonerado
                    empleados.IdTipoContratacion = 1;//1 significa Motivo No establecido
                    DAL_Empleados.Insertar(empleados);
                    MessageBox.Show("El Empleado fue agregado");
                    this.Close();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error en la base de datos: " + ex.Message);
                }
            }
        }
    }
}
