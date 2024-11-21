using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsMetodosDepartamentoBL
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
            return clsMetodosDepartamentoDAL.buscarDepartamentoPorId(id);
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
            return clsMetodosDepartamentoDAL.insertarDepartamento(departamento);
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
            return clsMetodosDepartamentoDAL.editarDepartamento(departamento);
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
            return clsMetodosDepartamentoDAL.eliminarDepartamento(id);
        }
    }
}
