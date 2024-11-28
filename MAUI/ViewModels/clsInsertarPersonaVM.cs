using BL;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using ENT;
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
    public class clsInsertarPersonaVM : INotifyPropertyChanged
    {
        #region Atributos
        private string nombre;
        private string apellidos;
        private string telefono;
        private string direccion;
        private string foto;
        private DateTime fechaNac;
        private string nombreDept;
        private List<clsDepartamento> departamentos;
        private clsDepartamento departamentoSeleccionado;
        private DelegateCommand insertarCommand;
        private DelegateCommand volverCommand;
        private bool showError;
        private bool showContent;
        private string error;
        #endregion

        #region Propiedades
        public string Nombre
        {
            get { return nombre; } 
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    nombre = value;
                    insertarCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Apellidos
        {
            get { return apellidos; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    apellidos = value;
                    insertarCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string Telefono
        {
            get { return telefono; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    telefono = value;
                    insertarCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    direccion = value;
                    insertarCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Foto
        {
            get { return foto; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    foto = value;
                    insertarCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DateTime FechaNac
        {
            get { return fechaNac; }
            set
            {
                fechaNac = value;
                insertarCommand.RaiseCanExecuteChanged();
            }
        }

        public string NombreDept
        {
            get { return nombreDept; }
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
                    insertarCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public DelegateCommand InsertarCommand
        {
            get { return insertarCommand; }
        }

        public DelegateCommand VolverCommand
        {
            get { return volverCommand; }
        }

        public bool ShowError
        {
            get { return showError; }
        }
        public bool ShowContent
        {
            get { return !showError; }
        }
        public string Error
        {
            get { return error; }
        }
        #endregion

        #region Constructor
        public clsInsertarPersonaVM() {
            fechaNac = DateTime.Now;
            insertarCommand = new DelegateCommand(insertarCommandExecuted, insertarCommandCanExecute);
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
        /// Función que inserta una persona en la base de datos
        /// <br></br>
        /// Pre: Todos los campos rellenos
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        public void insertarCommandExecuted()
        {
            try
            {
                clsPersona persona = new clsPersona(1, nombre, apellidos, telefono, direccion, foto, fechaNac, departamentoSeleccionado.Id);
                clsMetodosPersonaBL.insertarPersonaBL(persona);
                CancellationTokenSource token = new CancellationTokenSource();
                var toast = Toast.Make("Persona añadida correctamente", ToastDuration.Short, 14);
                toast.Show(token.Token);
                Shell.Current.GoToAsync("///listadoPersonas");
            } catch (Exception ex) {
                showError = true;
                error = ex.Message;
                NotifyPropertyChanged("ShowError");
                NotifyPropertyChanged("Error");
            }

        }

        /// <summary>
        /// Función que comprueba cuando puede mostrarse el command
        /// <br></br>
        /// Pre: Ninguna
        /// <br></br>
        /// Post: Ninguna
        /// </summary>
        /// <returns></returns>
        public bool insertarCommandCanExecute()
        {
            bool canExecute = false;

            if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(apellidos) && !string.IsNullOrEmpty(telefono)
                && !string.IsNullOrEmpty(direccion) && !string.IsNullOrEmpty(foto) && fechaNac != null && departamentoSeleccionado != null)
            {
                canExecute = true;
            }

            return canExecute;
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
