using GestorEmpleado.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleado.DAL
{
    public static class DAL_TipoContrataciones
    {
        public static void Insertar(TipoContrataciones entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("InsertTipoContratacion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", entidad.Tipo);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar insertar un tipo de contratacion en la base de datos: " + ex.Message);
            }
        }
        public static void Update(TipoContrataciones entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateTipoContratacion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Tipo", entidad.Tipo);
                cmd.Parameters.AddWithValue("@IdTipoContratacion", entidad.IdTipoContratacion);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar cambiar el registro en la base de datos: " + ex.Message);
            }
        }
        public static void Delete(TipoContrataciones entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteTipoContratacion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdTipoContratacion", entidad.IdTipoContratacion);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar eliminar un registro de la base de datos: " + ex.Message);
            }
        }
            public static DataTable GetList()
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from TipoContrataciones", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                conn.Close();
                conn.Dispose();
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al mostrar las TipoContrataciones: " + ex.Message);
            }
        }
    }
}
