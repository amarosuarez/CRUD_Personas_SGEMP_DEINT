using BL;
using ENT;

namespace ASP.Models.VM
{
    public class clsListadoPersonasConNombreDeptVM
    {
        #region Atributos
        private List<clsPersona> personas;
        private List<clsPersonaNombreDept> personasConNombreDept;
        #endregion

        #region Propiedades
        public List<clsPersonaNombreDept> PersonasConNombreDept
        {
            get { return personasConNombreDept; }
        }
        #endregion

        #region Constructores
        public clsListadoPersonasConNombreDeptVM()
        {
            personas = clsListadosPersonasBL.listadoCompletoPersonasBL();

            List<clsDepartamento> departamentos = clsListadoDepartamentoBL.listadoCompletoDepartamentosBL();
            personasConNombreDept = new List<clsPersonaNombreDept>();

            foreach (clsPersona persona in personas)
            {
                clsPersonaNombreDept personaNombreDept = new clsPersonaNombreDept(persona, departamentos);
                personasConNombreDept.Add(personaNombreDept);
            }
        }
        #endregion
    }
}
