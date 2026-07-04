using GestorEmpleado.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace GestorEmpleado.DAL
{
    public static class DAL_Empleados
    {
        public static void Insertar(Empleados entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("InsertEmpleados", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@FechaIngreso", entidad.FechaIngreso);
                cmd.Parameters.AddWithValue("@FechaExoneracion", entidad.FechaExoneracion);
                cmd.Parameters.AddWithValue("@IdMotivoExoneracion", entidad.IdMotivoExoneracion);
                cmd.Parameters.AddWithValue("@IdTipoContratacion", entidad.IdTipoContratacion);
                cmd.Parameters.AddWithValue("@IdSucursal", entidad.IdSucursal);
                cmd.Parameters.AddWithValue("@IdCargo", entidad.IdCargo);
                cmd.ExecuteScalar();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (SqlException ex)
            {
                throw new Exception("Error al intentar insertar un empleado en la base de datos: " + ex.Message);
            }
        }
        public static void Update(Empleados entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("UpdateEmpleado", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", entidad.Nombre);
                cmd.Parameters.AddWithValue("@FechaIngreso", entidad.FechaIngreso);
                cmd.Parameters.AddWithValue("@FechaExoneracion", entidad.FechaExoneracion);
                cmd.Parameters.AddWithValue("@IdMotivoExoneracion", entidad.IdMotivoExoneracion);
                cmd.Parameters.AddWithValue("@IdTipoContratacion", entidad.IdTipoContratacion);
                cmd.Parameters.AddWithValue("@IdSucursal", entidad.IdSucursal);
                cmd.Parameters.AddWithValue("@IdCargo", entidad.IdCargo);
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
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
        public static void Delete(Empleados entidad)
        {
            SqlConnection conn = new SqlConnection(Connection.ConextionString());
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("DeleteEmpleado", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
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
