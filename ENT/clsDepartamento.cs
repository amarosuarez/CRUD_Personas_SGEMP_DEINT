using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT
{
    public class clsDepartamento
    {

        #region Atributos
        private int id;
        private string nombre;
        #endregion

        #region Propiedades
        public int Id
        {
            get { return id; }
            set
            {
                if (value > 0)
                {
                    id = value;
                }
            }
        }

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                }
            }
        }
        #endregion

        #region Constructores
        public clsDepartamento() { }

        public clsDepartamento(int id, string nombre) {
            if (id > 0)
            {
                this.id = id;
            }

            if (!string.IsNullOrEmpty(nombre))
            {
                this.nombre = nombre;
            }
        }

        #endregion
    }
}
