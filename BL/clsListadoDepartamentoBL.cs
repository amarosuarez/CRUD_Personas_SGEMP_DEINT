using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsListadoDepartamentoBL
    {
        /// <summary>
        /// Obtiene un listado completo de los departamentos de la base de datos
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Puede devolver una lista vacía si no encuentra nada en la base de datos
        /// </summary>
        /// <returns>Lista de departamentos</returns>
        public static List<clsDepartamento> listadoCompletoDepartamentosBL()
        {
            return clsListadoDepartamentoDAL.listadoCompletoDepartamentosDAL();
        }

    }
}
