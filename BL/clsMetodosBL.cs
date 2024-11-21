using ENT;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class clsMetodosBL
    {
        /// <summary>
        /// Función que obtiene los detalles de una persona de la base de datos de azure, según su ID
        /// <br></br>
        /// Pre: El id debe ser mayor que 0
        /// <br></br>
        /// Post: Puede devolver null si no se encuentra a la persona en la BD
        /// </summary>
        /// <param name="id">ID de la persona a buscar</param>
        /// <returns>Objeto persona con sus detalles</returns>
        public static clsPersona buscarPersonaPorIdBL(int id)
        {
            return DAL.clsMetodosDAL.buscarPersonaPorIdDAL(id);
        }

        /// <summary>
        /// Función que inserta una persona en la base de datos de azure
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Puede devolver 0 filas afectadas si no se puede insertar a la persona
        /// </summary>
        /// <param name="persona">Objeto persona con los detalles a insertar en la base de datos de azure</param>
        /// <returns>Número de filas afectadas tras el insert</returns>
        public static int insertarPersonaBL(clsPersona persona)
        {
            return DAL.clsMetodosDAL.insertarPersonaDAL(persona);
        }

        /// <summary>
        /// Función que actualiza los campos de una persona, según su id
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Puede devolver 0 filas afectadas si no se puede editar a la persona porque no se encuentre
        /// </summary>
        /// <param name="persona">Objeto persona con los nuevos detalles</param>
        /// <returns>Número de filas afectadas tras la actualización</returns>
        public static int editarPersonaBL(clsPersona persona)
        {
            return DAL.clsMetodosDAL.editarPersonaDAL(persona);
        }

        /// <summary>
        /// Función que elimina una persona de la base de datos de azure, según su id
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Puede devolver 0 filas afectadas si no se puede eliminar a la persona porque no se encuentre
        /// </summary>
        /// <param name="id">ID de la persona a eliminar</param>
        /// <returns>Número de filas afectadas tras el borrado</returns>
        public static int eliminarPersonaBL(int id)
        {
            return DAL.clsMetodosDAL.eliminarPersonaDAL(id);
        }
    }
}
