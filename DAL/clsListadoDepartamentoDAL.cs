using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsListadoDepartamentoDAL
    {
        /// <summary>
        /// Obtiene un listado completo de los departamentos de la base de datos
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Puede devolver una lista vacía si no encuentra nada en la base de datos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public static List<clsDepartamento> listadoCompletoDepartamentosDAL()
        {
            List<clsDepartamento> listado = new List<clsDepartamento>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsDepartamento departamento;

            try
            {
                conexion = clsConexionDB.getConexion();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    miComando.CommandText = "SELECT * FROM departamentos";
                    miComando.Connection = conexion;
                    miLector = miComando.ExecuteReader();

                    if (miLector.HasRows)
                    {
                        while (miLector.Read())
                        {
                            departamento = new clsDepartamento();
                            departamento.Id = (int)miLector["ID"];
                            departamento.Nombre = (string)miLector["Nombre"];
                            
                            listado.Add(departamento);
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

            return listado;
        }
    }
}
