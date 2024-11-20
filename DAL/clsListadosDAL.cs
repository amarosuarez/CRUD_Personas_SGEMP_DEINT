using ENT;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class clsListadosDAL
    {
        /// <summary>
        /// Esta función estática devuelve un listado de personas de la base de datos de azure.
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<clsPersona> listadoCompletoPersonasDAL()
        {
            List<clsPersona> listadoPersonas = new List<clsPersona>();

            SqlConnection conexion = new SqlConnection();
            SqlCommand miComando = new SqlCommand();
            SqlDataReader miLector;
            clsPersona persona;

            try
            {
                conexion = clsConexionDB.getConexion();
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    miComando.CommandText = "SELECT * FROM personas";
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
                            listadoPersonas.Add(persona);
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

            return listadoPersonas;
        }
    }
}
