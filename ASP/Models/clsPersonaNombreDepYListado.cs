using BL;
using ENT;

namespace ASP.Models
{
    public class clsPersonaNombreDepYListado : clsPersonaNombreDept
    {
        #region Atributos
        private List<clsDepartamento> departamentos;
        private int departamentoSeleccionado;
        #endregion

        #region Propiedades
        public List<clsDepartamento> Departamentos
        {
            get { return departamentos; }
        }

        public int DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                departamentoSeleccionado = value;
            }
        }
        #endregion

        #region Constructores

        public clsPersonaNombreDepYListado(int id) : base(id)
        {
            
            departamentos = clsListadoDepartamentoBL.listadoCompletoDepartamentosBL();
            clsPersona persona = clsMetodosPersonaBL.buscarPersonaPorIdBL(id);
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.Telefono = persona.Telefono;
            this.IdDepartamento = persona.IdDepartamento;

            departamentoSeleccionado = persona.IdDepartamento;

        }
        #endregion

        #region Métodos
        public clsPersona GetPersona()
        {
            clsPersona persona = new clsPersona(this.Id, this.Nombre, this.Apellidos, this.Telefono, this.Direccion, this.Foto, this.FechaNacimiento, departamentoSeleccionado);
            return persona;
        }
        #endregion
    }
}
