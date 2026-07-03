using GestorEmpleado.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GestorEmpleado.DAL
{
    public static class DAL_Cargos
    {
        //Función para insertar un nuevo cargo en la base de datos
        public static void Insertar(Cargos entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());//Creamos una conexión con la base de datos usando el "ConextionString" que previamente creamos
            conn.Open();//Abrimos la conexión

            try
            {
                SqlCommand cmd = new SqlCommand("InsertarCargo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch(SqlException ex)
            {
                throw new Exception("Error al intentar insertar un usuario en la base de datos: " + ex.Message);
            }
        }
        //Función para cambiar un cargo de la base de datos
        public static void Update(Cargos entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateCargo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@IdCargo", entidad.IdCargo);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar cambiar el cargo en la base de datos: " + ex.Message);
            }
        }
        //Función para eliminar un cargo de la base de datos (Pero en realidad solo desabilitamos el campo activo del registro)
        public static void Delete(Cargos entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteCargo", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdCargo", entidad.IdCargo);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch(SqlException ex)
            {
                throw new Exception("Error al intentar eliminar un registro de la base de datos: " + ex.Message);
            }
        }
    }
}
