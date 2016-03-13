using System;
using CharlaMVVM.Common.Messages.EditarPersonaMessages;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CharlaMVVM.ViewModels
{
    public class EditarPersonaViewModel : ViewModelBase
    {
        public EditarPersonaViewModel()
        {
            //Inicializamos Commands.
            GuardarDatosCommand = new RelayCommand(GuardaDatos, ValidaNombre);
            CancelarDatosCommand = new RelayCommand(CancelaDatos);
        }

        /// <summary>
        /// Variable privada para almacenar el nombre de la persona a editar.
        /// </summary>
        private string _nombrePersona;

        /// <summary>
        /// Nombre de la persona a editar.
        /// </summary>
        public string NombrePersona
        {
            get { return _nombrePersona; }
            set
            {
                _nombrePersona = value;

                //Al cambiar el valor del nombre, reevaluamos la condición de ejecución del Command.
                GuardarDatosCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        /// Identificador de la persona a editar.
        /// </summary>
        public Guid IdPersona { get; set; }

        /// <summary>
        /// Command para guardar los datos editados.
        /// </summary>
        public RelayCommand GuardarDatosCommand { get; private set; }

        /// <summary>
        /// Command para cancelar la introducción de datos.
        /// </summary>
        public RelayCommand CancelarDatosCommand { get; private set; }

        /// <summary>
        /// Cancela la introducción de datos de la persona.
        /// </summary>
        private void CancelaDatos()
        {
            //Notificamos a la vista de que hemos cancelado la edición de datos.
            Messenger.Default.Send(new DatosPersonaListosMessage(false, NombrePersona));
        }

        /// <summary>
        /// Valida el nombre.
        /// </summary>
        /// <returns>Valor binario que indica si el nombre es válido.</returns>
        public bool ValidaNombre()
        {
            return !string.IsNullOrEmpty(NombrePersona);
        }

        /// <summary>
        /// Guarda los datos de la persona.
        /// </summary>
        private void GuardaDatos()
        {
            //Notificamos a la vista de que los datos actualizados ya han sido introducidos y validados.
            Messenger.Default.Send(new DatosPersonaListosMessage(true, NombrePersona));
        }
    }
}
