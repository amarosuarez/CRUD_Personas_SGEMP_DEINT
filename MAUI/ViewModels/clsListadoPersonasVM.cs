using BL;
using ENT;
using MAUI.Models;
using MAUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Utilidades;

namespace MAUI.ViewModels
{
    public class clsListadoPersonasVM : INotifyPropertyChanged
    {
        #region Atributos
        private clsPersona personaSeleccionada;
        private ObservableCollection<clsPersonaNombreDept> listadoPersonasNombreDept;
        private List<clsPersona> listadoPersonas;
        private DelegateCommand editarCommand;
        #endregion

        #region Propiedades
        public clsPersona PersonaSeleccionada
        {
            get { return personaSeleccionada; }
            set
            {
                if (value != null)
                {
                    personaSeleccionada = value;
                    NotifyPropertyChanged();
                    editarCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public ObservableCollection<clsPersonaNombreDept> ListadoPersonasNombreDept
        {
            get { return listadoPersonasNombreDept; }
        }
        public DelegateCommand EditarCommand
        {
            get { return editarCommand; }
        }
        #endregion

        #region Constructores
        public clsListadoPersonasVM()
        {
            listadoPersonas = clsListadosPersonasBL.listadoCompletoPersonasBL();
            listadoPersonasNombreDept = new ObservableCollection<clsPersonaNombreDept>();

            // se crea una lista de departamentos
            List<clsDepartamento> listaDept = clsListadoDepartamentoBL.listadoCompletoDepartamentosBL();

            foreach (clsPersona persona in listadoPersonas)
            {
                clsPersonaNombreDept personaNombreDept = new clsPersonaNombreDept(persona, listaDept);
                listadoPersonasNombreDept.Add(personaNombreDept);
            }

            editarCommand = new DelegateCommand(editarCommandExecuted, editarCommandCanExecute);
        }
        #endregion

        #region Comandos
        public async void editarCommandExecuted()
        {
            if (PersonaSeleccionada != null)
            {
                var queryParams = new Dictionary<string, object>
        {
            { "persona", PersonaSeleccionada }
        };

                await Shell.Current.GoToAsync("editarPersona", queryParams);
            }
        }

        public bool editarCommandCanExecute()
        {
            bool canExecute = false;

            if (personaSeleccionada != null)
            {
                canExecute = true;
            }

            return canExecute;
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
