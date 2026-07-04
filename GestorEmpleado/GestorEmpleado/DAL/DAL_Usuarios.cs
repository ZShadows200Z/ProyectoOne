using GestorEmpleado.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GestorEmpleado.DAL
{
    public static class DAL_Usuarios
    {
        public static void Insertar(Usuarios Entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("InsertUsuario", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Usuario", Entidad.Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", Entidad.Contraseña);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar agregar un usuario nuevo en la base de datos: " + ex.Message);
            }
        }

        public static void Update(Usuarios Entidad, int CambiarPassword)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateUsuario", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", Entidad.IdUsusario);
                cmd.Parameters.AddWithValue("@Nombre", Entidad.Nombre);
                cmd.Parameters.AddWithValue("@Usuario", Entidad.Usuario);
                cmd.Parameters.AddWithValue("@Contraseña", Entidad.Contraseña);
                cmd.Parameters.AddWithValue("@CambiarPassword", CambiarPassword);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar cambiar el usuario en la base de datos: " + ex.Message);
            }
        }

        public static void Delete(Usuarios Entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteUsuario", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", Entidad.IdUsusario);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al eliminar el Usuario en la base de datos: " + ex.Message);
            }
        }
        public static bool ValidateLogin(Usuarios entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();
            byte[] contraseña;
            try
            {
                SqlCommand cmd = new SqlCommand("ValidateLogin", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuarios", entidad.Usuario);
                contraseña = (byte[])cmd.ExecuteScalar();
                if(contraseña != null)
                {
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                    bool comprobarHash = entidad.Contraseña.SequenceEqual(contraseña);
                    return comprobarHash;
                }
                return false;
            }
            catch(SqlException ex)
            {
                throw new Exception("Error base de datos: " + ex.Message);
            }
        }
    }
}
