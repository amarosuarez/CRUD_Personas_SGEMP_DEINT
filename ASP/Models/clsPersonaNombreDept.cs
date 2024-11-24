using BL;
using DAL;
using ENT;

namespace ASP.Models
{
    public class clsPersonaNombreDept : clsPersona
    {
        #region Atriutos
        private string nombreDept;
        #endregion

        #region Propiedades
        public string NombreDept
        {
            get { return nombreDept; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    nombreDept = value;
                }
            }
        }
        #endregion

        #region Constructores
        public clsPersonaNombreDept(clsPersona persona)
        {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdDepartamento = persona.IdDepartamento;

            clsDepartamento dep = clsMetodosDepartamentoBL.buscarDepartamentoPorId(this.IdDepartamento);
            
            if (dep != null)
            {
                this.nombreDept = dep.Nombre;
            }
        }

        public clsPersonaNombreDept(int idPersona)
        {
            clsPersona persona = clsMetodosPersonaBL.buscarPersonaPorIdBL(idPersona);

            if (persona != null)
            {
                this.Id = persona.Id;
                this.Nombre = persona.Nombre;
                this.Apellidos = persona.Apellidos;
                this.Telefono = persona.Telefono;
                this.Direccion = persona.Direccion;
                this.Foto = persona.Foto;
                this.FechaNacimiento = persona.FechaNacimiento;
                this.IdDepartamento = persona.IdDepartamento;

                clsDepartamento dep = clsMetodosDepartamentoBL.buscarDepartamentoPorId(this.IdDepartamento);

                if (dep != null)
                {
                    this.nombreDept = dep.Nombre;
                }
            }

        }
        #endregion
    }
}
