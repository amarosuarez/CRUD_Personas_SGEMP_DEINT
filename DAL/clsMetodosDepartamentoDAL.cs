using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsMetodosDepartamentoDAL
    {
        /// <summary>
        /// Función que obtiene los detalles de un departamento de la base de datos de azure, según su ID
        /// <br></br>
        /// Pre: El id debe ser mayor que 0
        /// <br></br>
        /// Post: Puede devolver null si no se encuentra al departamento en la BD
        /// </summary>
        /// <param name="id">ID del departamento a buscar</param>
        /// <returns>Objeto departamento con sus detalles</returns>
        public static clsDepartamento buscarDepartamentoPorId(int id)
        {
            clsDepartamento departamento = null;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                    miComando.CommandText = "SELECT * FROM departamentos WHERE ID = @id";
                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        while (miLector.Read())
                        {
                            departamento = new clsDepartamento();
                            departamento.Id = (int)miLector["ID"];
                            departamento.Nombre = (string)miLector["Nombre"];
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

            return departamento;
        }

        /// <summary>
        /// Función que inserta un departamento en la base de datos de azure
        /// <br></br>
        /// Pre: Departamento con nombre
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        /// <param name="departamento">Objeto departamento con los detalles a insertar en la base de datos de azure</param>
        /// <returns>Número de filas afectadas tras el insert</returns>
        public static int insertarDepartamento(clsPersona departamento)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();

                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;

                miComando.CommandText = "INSERT INTO Departamentos " +
                    "VALUES (@nombre)";
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
        /// Función que actualiza los campos de un departamento, según su id
        /// <br></br>
        /// Pre: Departamento con nombre relleno
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        /// <param name="departamento">Objeto departamento con los nuevos detalles</param>
        /// <returns>Número de filas afectadas tras la actualización</returns>
        public static int editarDepartamento(clsDepartamento departamento)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();

                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = departamento.Id;
                miComando.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = departamento.Nombre;

                miComando.CommandText = "UPDATE Departamentos " +
                    "SET Nombre = @nombre" +
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
        /// Función que elimina un departamento de la base de datos de azure, según su id
        /// <br></br>
        /// Pre: El id debe ser mayor que 0
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        /// <param name="id">ID del departamento a eliminar</param>
        /// <returns>Número de filas afectadas tras el borrado</returns>
        public static int eliminarDepartamento(int id)
        {
            int numeroFilasAfectadas = 0;

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;

            try
            {
                conexion = clsConexionDB.getConexion();

                miComando.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
                miComando.CommandText = "DELETE FROM Departamentos WHERE ID = @id";
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
