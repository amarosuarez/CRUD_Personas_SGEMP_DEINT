using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ENT;

namespace MAUI.Models
{
    public class clsPersonaNombreDept : clsPersona
    {
        #region Atributos
        private string nombreDept;
        #endregion

        #region Propiedades
        public string NombreDept { get { return nombreDept; } }
        #endregion

        #region Constructores
        public clsPersonaNombreDept(clsPersona persona, List<clsDepartamento> listaDepartamentos)
        {
            if (persona != null)
            {
                Id = persona.Id;
                Nombre = persona.Nombre;
                Apellidos = persona.Apellidos;
                Telefono = persona.Telefono;
                Direccion = persona.Direccion;
                Foto = persona.Foto;
                FechaNacimiento = persona.FechaNacimiento;
                IdDepartamento = persona.IdDepartamento;

                nombreDept = listaDepartamentos.First(dep => dep.Id == persona.IdDepartamento).Nombre;
            }
        }
        #endregion

    }
}
