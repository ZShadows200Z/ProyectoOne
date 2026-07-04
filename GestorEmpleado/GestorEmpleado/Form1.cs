using GestorEmpleado.DAL;
using GestorEmpleado.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorEmpleado
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //Validación de espacio en blanco y nullos en textBox Usuarios
        private byte[] GenerarHash(string contraseña)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                return sha512.ComputeHash(Encoding.UTF8.GetBytes(contraseña));
            }
        }
        private bool ValidateUsuarioNull()
        {
            if(string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("No ha ingresado un usuario");
                return false;
            }
            return true;
        }
        private bool ValidatePasswordNull()
        {
            if(string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("No ha ingresado una contraseña");
                return false;
            }
            return true;
        }

        //Botton INGRESAR
        private void button1_Click(object sender, EventArgs e)
        {
            Usuarios entidad = new Usuarios();

            if (ValidateUsuarioNull() && ValidatePasswordNull())
            {
                entidad.Usuario = Regex.Replace(textBox1.Text.Trim(), "[^a-zA-Z0-9]", "");
                entidad.Contraseña = GenerarHash(textBox2.Text.Trim());

                if (DAL_Usuarios.ValidateLogin(entidad))
                {
                    MessageBox.Show("Ingresando a la App");
                    this.DialogResult = DialogResult.OK; //Mandamos a decir a program.cs que la validación fue exitosa
                    this.Close();//Cerramos el login
                }
                else
                {
                    MessageBox.Show("El usuario o la contraseña no son validos");
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click_3(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
