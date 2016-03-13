using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight;
using System.Collections.ObjectModel;
using CharlaMVVM.Models;
using System.Linq;
using System.Collections.Generic;

namespace CharlaMVVM.ViewModels
{
    public class BindingBasicoViewModel : ViewModelBase
    {
        public BindingBasicoViewModel()
        {
            //Inicializamos la lista de personas con algún elemento.
            var personas = GeneraPersonasPrueba();
            Personas = new ObservableCollection<PersonaModel>(personas);

            //Inicializamos los Command.
            ResetearCommand = new RelayCommand(Resetear);
            SaludarCommand = new RelayCommand(Saludar);
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

        /// <summary>
        /// Método para resetear la lista de personas con los datos iniciales.
        /// </summary>
        public void Resetear()
        {
            var personas = GeneraPersonasPrueba();
            Personas = new ObservableCollection<PersonaModel>(personas);
        }

        /// <summary>
        /// Command para resetear la lista de personas con los datos iniciales.
        /// </summary>
        public ICommand ResetearCommand
        {
            get;
            private set;
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
            var nombres = string.Empty;
            foreach (var p in Personas)
            {
                if (string.IsNullOrEmpty(nombres))
                {
                    nombres = string.Format("{0}", p.Nombre);
                }
                else
                {
                    nombres = string.Format("{0},{1}", nombres, p.Nombre);
                }
            }
            Saludo = string.Format("¡Hola {0}!", nombres);
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
