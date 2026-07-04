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
    public partial class Editar : Form
    {
        public Editar()
        {
            InitializeComponent();
        }

       
        private void Editar_Load(object sender, EventArgs e)
        {

            CargarComboTipoContrato();
            CargarComboMotivoExoneracion();

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
        
        }

        private void chkActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        private void chkActivo_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmbSucursal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void CargarComboSucursales()
        {
            DataTable dt = DAL_Sucursales.GetList();

            DataRow filaInicial = dt.NewRow();
            filaInicial["IdSucursal"] = 0;
            filaInicial["Nombre"] = "Sucursales";
            dt.Rows.InsertAt(filaInicial, 0);

            cmbSucursal.DataSource = dt;
            cmbSucursal.DisplayMember = "Nombre";
            cmbSucursal.ValueMember = "IdSucursal";
        }
        private void CargarComboTipoContrato()
        {
            DataTable dt = DAL_TipoContrataciones.GetList();

            DataRow filaInicial = dt.NewRow();
            filaInicial["IdTipoContratacion"] = 0;
            filaInicial["Tipo"] = "Tipo_Contratacion";
            dt.Rows.InsertAt(filaInicial, 0);

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Tipo";
            comboBox1.ValueMember = "IdTipoContratacion";
        }
        private void CargarComboMotivoExoneracion()
        {
            DataTable dt = DAL_MotivoExoneraciones.GetList();

            DataRow filaInicial = dt.NewRow();
            filaInicial["IdMotivoExoneracion"] = 0;
            filaInicial["Motivo"] = "Tipo_Exoneracion";
            dt.Rows.InsertAt(filaInicial, 0);

            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Motivo";
            comboBox2.ValueMember = "IdMotivoExoneracion";
        }
    }
}
