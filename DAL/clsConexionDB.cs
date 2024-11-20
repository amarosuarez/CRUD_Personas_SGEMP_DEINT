using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class clsConexionDB
    {
        public static SqlConnection getConexion()
        {
            SqlConnection miConexion = new SqlConnection();

            try
            {

                miConexion.ConnectionString = "server=amaro.database.windows.net;database=amaroDB;uid=usuario;pwd=LaCampana123;trustServerCertificate = true;";

                miConexion.Open();

            }
            catch (Exception ex)
            {
                throw;
            }

            return miConexion;
        }


    }

}
