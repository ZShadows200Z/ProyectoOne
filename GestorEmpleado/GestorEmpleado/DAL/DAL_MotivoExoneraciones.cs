using GestorEmpleado.Modelos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorEmpleado.DAL
{
    public static class DAL_MotivoExoneraciones
    {
        public static void Insertar(MotivoExoneraciones entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("InsertMotivoExoneracion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Motivo", entidad.Motivo);
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
        public static void Update(MotivoExoneraciones entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateMotivoExoneracion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Motivo", entidad.Motivo);
                cmd.Parameters.AddWithValue("@IdMotivoExoneracion", entidad.IdMotivoExoneracion);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar cambiar el motivo de exoneracion en la base de datos: " + ex.Message);
            }
        }
        public static void Delete(MotivoExoneraciones entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DeletoMotivoExoneracion", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdMotivoExoneracion", entidad.IdMotivoExoneracion);
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

    }
}