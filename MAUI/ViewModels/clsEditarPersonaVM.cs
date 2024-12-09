using BL;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using DAL;
using ENT;
using MAUI.Models;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Utilidades;

namespace MAUI.ViewModels
{
    [QueryProperty(nameof(Persona), "persona")]
    public class clsEditarPersonaVM : INotifyPropertyChanged
    {
        #region Atributos
        private clsPersona persona;
        private List<clsDepartamento> departamentos;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand guardarCommand;
        private DelegateCommand volverCommand;
        private String error;
        private bool showError;
        private bool showContent;
        private string nombreDept;
        #endregion

        #region Propiedades
        public clsPersona Persona
        {
            get { return persona; }
            set
            {
                persona = value;
                departamentoSeleccionado = clsMetodosDepartamentoBL.buscarDepartamentoPorIdBL(value.IdDepartamento);
                nombreDept = departamentoSeleccionado.Nombre;
                NotifyPropertyChanged(nameof(NombreDept));
                NotifyPropertyChanged("Persona");
                NotifyPropertyChanged("DepartamentoSeleccionado");
            }
        }

        public List<clsDepartamento> Departamentos
        {
            get { return departamentos; }
        }

        public clsDepartamento DepartamentoSeleccionado
        {
            get { return departamentoSeleccionado; }
            set
            {
                if (value != null)
                {
                    departamentoSeleccionado = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public DelegateCommand GuardarCommand
        {
            get { return guardarCommand; }
        }

        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }

        public string Error
        {
            get { return error; }
        }

        public bool ShowError
        {
            get { return showError; }
        }

        public bool ShowContent
        {
            get { return !showError; }
        }

        public string NombreDept
        {
            get { return nombreDept; }
        }
        #endregion

        #region Constructores
        public clsEditarPersonaVM()
        {

            guardarCommand = new DelegateCommand(guardarCommandExecuted);
            volverCommand = new DelegateCommand(volverCommandExecuted);

            try
            {
                departamentos = clsListadoDepartamentoBL.listadoCompletoDepartamentosBL();
                
            }
            catch (Exception ex)
            {
                
                error = "Ha ocurrido un error";   
                showError = true;
                NotifyPropertyChanged("Error");
                NotifyPropertyChanged("ShowError");
            }
        }
        #endregion

        #region Commands
        /// <summary>
        /// Función que actualiza una persona en la base de datos
        /// <br></br>
        /// Pre: Persona no nula
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void guardarCommandExecuted()
        {
            try
            {
                if (persona != null)
                {
                    persona.IdDepartamento = departamentoSeleccionado.Id;
                    int filasAfectadas = clsMetodosPersonaBL.editarPersonaBL(persona);

                    if (filasAfectadas > 0)
                    {
                        CancellationTokenSource token = new CancellationTokenSource();
                        var toast = Toast.Make("Persona editada correctamente", ToastDuration.Short, 14);
                        await toast.Show(token.Token);
                        await Shell.Current.GoToAsync("///listadoPersonas");
                    }
                }
            } catch (Exception ex)
            {
                showError = true;
                error = ex.Message;
                NotifyPropertyChanged("ShowError");
                NotifyPropertyChanged("Error");
            }
        }

        /// <summary>
        /// Función que vuelve al listado
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public async void volverCommandExecuted()
        {
            await Shell.Current.GoToAsync("///listadoPersonas");
        }
        #endregion

        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")

        {

            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propertyName));

        }
        #endregion
    }
}
