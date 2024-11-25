using BL;
using ENT;

namespace ASP.Models
{
    public class clsListadoPersonasConNombreDept
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
        public clsListadoPersonasConNombreDept()
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
