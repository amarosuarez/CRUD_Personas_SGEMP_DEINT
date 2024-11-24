﻿using BL;
using ENT;

namespace ASP.Models
{
    public class clsListadoPersonasConNombreDept
    {
        #region Atributos
        private List<clsPersona> personas { get; }
        private List<clsPersonaNombreDept> personasConNombreDept;
        #endregion

        #region Propiedades
        public List<clsPersonaNombreDept> PersonasConNombreDept
        {
            get { return personasConNombreDept; }
            set
            {
                personasConNombreDept = value;
            }
        }
        #endregion

        #region Constructores
        public clsListadoPersonasConNombreDept()
        {
            personas = clsListadosPersonasBL.listadoCompletoPersonasBL();

            personasConNombreDept = new List<clsPersonaNombreDept>();
            foreach (clsPersona persona in personas)
            {
                clsPersonaNombreDept personaNombreDept = new clsPersonaNombreDept(persona);
                personasConNombreDept.Add(personaNombreDept);
            }
        }
        #endregion
    }
}