using System.Collections.Generic;
using System.Collections.ObjectModel;
using CharlaMVVM.Models;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace CharlaMVVM.ViewModels
{
    public class EventToCommandViewModel : ViewModelBase
    {
        public EventToCommandViewModel()
        {
            //Inicializamos la lista de personas con algún elemento.
            var personas = GeneraPersonasPrueba();
            Personas = new ObservableCollection<PersonaModel>(personas);

            //Inicializamos Commands.
            SeleccionarPersona = new RelayCommand<PersonaModel>(Selec_Persona);
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
        private static void Selec_Persona(PersonaModel personaSelected)
        {
            if (personaSelected != null)
            {
                //Enviamos el mensaje a la vista para mostrarlo.
                Messenger.Default.Send(new NotificationMessage(string.Format("¡Hola {0}!", personaSelected.Nombre)));
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
                new PersonaModel{Nombre="Iván"},
                new PersonaModel{Nombre="Alberto"},
                new PersonaModel{Nombre="Víctor"},
                new PersonaModel{Nombre="Pepe"}
            };
        }
    }
}
