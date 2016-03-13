using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using CharlaMVVM.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using CharlaMVVM.Common.Messages.EditarPersonaMessages;

namespace CharlaMVVM.ViewModels
{
    public class MessagingAvanzadoViewModel : ViewModelBase
    {
        public MessagingAvanzadoViewModel()
        {
            //Inicializamos la lista de personas con algún elemento.
            var personas = GeneraPersonasPrueba();
            Personas = new ObservableCollection<PersonaModel>(personas);

            //Inicializamos Commands.
            SeleccionarPersona = new RelayCommand<PersonaModel>(Selec_Persona);

            //Para que el modelo de vista guarde los datos de la persona cuando estén listos.
            Messenger.Default.Register<GuardarDatosPersonaMessage>(this, GuardaDatosPersona);
        }

        /// <summary>
        /// Identificador de la persona seleccionada actualmente.
        /// </summary>
        public Guid IdPersonaSeleccionada { get; set; }

        /// <summary>
        /// Guarda los datos editados de la persona.
        /// </summary>
        /// <param name="msg">Mensaje con los datos actualizados de la persona.</param>
        private void GuardaDatosPersona(GuardarDatosPersonaMessage msg)
        {
            //Sólo si debemos guardar los datos (el usuario no canceló la operación)
            if (!msg.AccionAceptar)
            {
                return;
            }
            var personaActualizar = Personas.FirstOrDefault(p => p.Id == IdPersonaSeleccionada);
            personaActualizar.Nombre = msg.NombrePersona;
        }

        /// <summary>
        /// Command para seleccionar una persona.
        /// </summary>
        public RelayCommand<PersonaModel> SeleccionarPersona
        {
            get;
            private set;
        }

        /// <summary>
        /// Método del Command de selección de una persona.
        /// </summary>
        /// <param name="personaSelected">Persona seleccionada.</param>
        private void Selec_Persona(PersonaModel personaSelected)
        {
            //Si la persona es correcta, avisamos a la vista para que pida al usuario los datos actualizados de ésta.
            if (personaSelected != null)
            {
                IdPersonaSeleccionada = personaSelected.Id;
                Messenger.Default.Send(new ObtenerDatosPersonaMessage());
            }
        }

        /// <summary>
        /// Variable privada con la lista de personas.
        /// </summary>
        private ObservableCollection<PersonaModel> _personas;

        /// <summary>
        /// Propiedad pública con la lista de personas.
        /// </summary>
        public ObservableCollection<PersonaModel> Personas
        {
            get { return _personas; }
            set
            {
                _personas = value;

                //Notificamos que se ha cambiado la lista.
                RaisePropertyChanged("Personas");
            }

        }

        /// <summary>
        /// Genera una lista de personas de prueba.
        /// </summary>
        /// <returns>Una lista de <see cref="PersonaModel"/>.</returns>
        private static IList<PersonaModel> GeneraPersonasPrueba()
        {
            return new List<PersonaModel>
            {
                new PersonaModel{Nombre="Iván", Id = Guid.NewGuid()},
                new PersonaModel{Nombre="Alberto", Id = Guid.NewGuid()},
                new PersonaModel{Nombre="Víctor", Id = Guid.NewGuid()},
                new PersonaModel{Nombre="Pepe", Id = Guid.NewGuid()}
            };
        }
    }
}
