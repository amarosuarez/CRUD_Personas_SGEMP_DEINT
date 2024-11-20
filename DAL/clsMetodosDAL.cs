using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsMetodosDAL
    {
        /// <summary>
        /// Función que obtiene los detalles de una persona de la base de datos de azure, según su ID
        /// </summary>
        /// <param name="id">ID de la persona a buscar</param>
        /// <returns>Objeto persona con sus detalles</returns>
        public static clsPersona buscarPersonaPorIdDAL(int id)
        {
            clsPersona persona = null;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                    miComando.CommandText = "SELECT * FROM personas WHERE ID = @id";
                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        while (miLector.Read())
                        {
                            persona = new clsPersona();
                            persona.Id = (int)miLector["ID"];
                            persona.Nombre = (string)miLector["Nombre"];
                            persona.Apellidos = (string)miLector["Apellidos"];
                            
                            if (miLector["Telefono"] != System.DBNull.Value)
                            {
                                persona.Telefono = (string)miLector["Telefono"];
                            }

                            if (miLector["Direccion"] != System.DBNull.Value)
                            {
                                persona.Direccion = (string)miLector["Direccion"];
                            }
                            
                            if (miLector["Foto"] != System.DBNull.Value)
                            {
                                persona.Foto = (string)miLector["Foto"];
                            }

                            if (miLector["FechaNacimiento"] != System.DBNull.Value)
                            {
                                persona.FechaNacimiento = (DateTime)miLector["FechaNacimiento"];
                            }

                            if (miLector["IDDepartamento"] != System.DBNull.Value)
                            {
                                persona.IdDepartamento = (int)miLector["IDDepartamento"];
                            }
                        }
                    }
                    miLector.Close();
                }
            }
            catch (SqlException ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return persona;
        }

        /// <summary>
        /// Función que inserta una persona en la base de datos de azure
        /// </summary>
        /// <param name="persona">Objeto persona con los detalles a insertar en la base de datos de azure</param>
        /// <returns>Número de filas afectadas tras el insert</returns>
        public static int insertarPersonaDAL(clsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();

                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
                miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
                miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

                miComando.CommandText = "INSERT INTO Personas " +
                    "VALUES (@nombre, @apellidos, @telefono, @direccion, @foto, @fechaNacimiento, @idDepartamento)";
                miComando.Connection = conexion;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Función que actualiza los campos de una persona, según su id
        /// </summary>
        /// <param name="persona">Objeto persona con los nuevos detalles</param>
        /// <returns>Número de filas afectadas tras la actualización</returns>
        public static int editarPersonaDAL(clsPersona persona)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();

                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = persona.Id;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = persona.Nombre;
                miComando.Parameters.Add("@apellidos", System.Data.SqlDbType.VarChar).Value = persona.Apellidos;
                miComando.Parameters.Add("@telefono", System.Data.SqlDbType.VarChar).Value = persona.Telefono;
                miComando.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar).Value = persona.Direccion;
                miComando.Parameters.Add("@foto", System.Data.SqlDbType.VarChar).Value = persona.Foto;
                miComando.Parameters.Add("@fechaNacimiento", System.Data.SqlDbType.DateTime).Value = persona.FechaNacimiento;
                miComando.Parameters.Add("@idDepartamento", System.Data.SqlDbType.Int).Value = persona.IdDepartamento;

                miComando.CommandText = "UPDATE Personas " +
                    "SET Nombre = @nombre, Apellidos = @apellidos, Telefono = @telefono, Direccion = @direccion, " +
                    "Foto = @foto, FechaNacimiento = @fechaNacimiento, IDDepartamento = @idDepartamento " +
                    "WHERE ID = @id";
                miComando.Connection = conexion;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                conexion.Close();
            }

            return numeroFilasAfectadas;
        }

        /// <summary>
        /// Función que elimina una persona de la base de datos de azure, según su id
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <returns>Número de filas afectadas tras el borrado</returns>
        public static int eliminarPersonaDAL(int id)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();

                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                miComando.CommandText = "DELETE FROM Personas WHERE ID = @id";
                miComando.Connection = conexion;

                numeroFilasAfectadas = miComando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            } finally
            {
                conexion.Close();
            }

            return numeroFilasAfectadas;
        }
    }
}
