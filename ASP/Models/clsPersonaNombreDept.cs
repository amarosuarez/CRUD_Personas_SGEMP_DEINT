﻿using BL;
using DAL;
using ENT;

namespace ASP.Models
{
    public class clsPersonaNombreDept : clsPersona
    {
        #region Atributos
        private string nombreDept;
        #endregion

        #region Propiedades
        public string NombreDept
        {
            get { return nombreDept; }
        }
        #endregion

        #region Constructores
        public clsPersonaNombreDept() { 
        }
        public clsPersonaNombreDept(clsPersona persona, List<clsDepartamento> listaDepartamentos)
        {
            this.Id = persona.Id;
            this.Nombre = persona.Nombre;
            this.Apellidos = persona.Apellidos;
            this.Telefono = persona.Telefono;
            this.Direccion = persona.Direccion;
            this.Foto = persona.Foto;
            this.FechaNacimiento = persona.FechaNacimiento;
            this.IdDepartamento = persona.IdDepartamento;

            string dep = listaDepartamentos.First(dept => dept.Id == persona.IdDepartamento).Nombre;
            nombreDept = dep;
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

                clsDepartamento dep = clsMetodosDepartamentoBL.buscarDepartamentoPorIdBL(this.IdDepartamento);

                if (dep != null)
                {
                    this.nombreDept = dep.Nombre;
                }
            }

        }
        #endregion
    }
}
