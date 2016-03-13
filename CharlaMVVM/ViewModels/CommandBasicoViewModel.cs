using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;

namespace CharlaMVVM.ViewModels
{
    public class CommandBasicoViewModel : ViewModelBase
    {
        public CommandBasicoViewModel()
        {
            //Inicializamos los Commands.
            SaludarCommand = new RelayCommand(Saludar, ValidaNombre);
        }

        /// <summary>
        /// Valida el nombre.
        /// </summary>
        /// <returns>Valor binario que indica si el nombre es válido.</returns>
        public bool ValidaNombre()
        {
            return !string.IsNullOrEmpty(Nombre);
        }

        //Variable privada con el nombre.
        private string _nombre;

        //Propiedad pública con el nombre.
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;

                //Al cambiar el valor del nombre, reevaluamos la condición de ejecución del Command.
                var saludarCommandTipado = SaludarCommand as RelayCommand;
                if (saludarCommandTipado != null)
                {
                    saludarCommandTipado.RaiseCanExecuteChanged();
                }
            }
        }

        /// <summary>
        /// Variable privada para almacenar el saludo completo.
        /// </summary>
        private string _saludo;

        /// <summary>
        /// Variable que almacena la cadena con el saludo completo.
        /// </summary>
        public string Saludo
        {
            get { return _saludo; }
            set
            {
                _saludo = value;
                     
                //Avisamos a la vista de que el valor de la propiedad ha cambiado.
                RaisePropertyChanged("Saludo");
            }
        }

        /// <summary>
        /// Método para emitir un saludo.
        /// </summary>
        public void Saludar()
        {
            Saludo = string.Format("¡Hola {0}!", Nombre);
        }

        /// <summary>
        /// Command para saludar.
        /// </summary>
        public ICommand SaludarCommand
        {
            get;
            private set;
        }
    }
}
