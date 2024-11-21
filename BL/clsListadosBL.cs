using ENT;
using Microsoft.Data.SqlClient;

namespace BL
{
    public class clsListadosBL
    {
        /// <summary>
        /// Esta función estática devuelve un listado de personas de la base de datos de azure.
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Puede devolver un listado vacío, por algún error con la BD
        /// </summary>
        /// <returns>Listado de personas</returns>
        public static List<clsPersona> listadoCompletoPersonasBL()
        {
            return DAL.clsListadosDAL.listadoCompletoPersonasDAL();
        }
    }
}
