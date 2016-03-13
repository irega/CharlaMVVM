using GalaSoft.MvvmLight;
using System;

namespace CharlaMVVM.Models
{
    /// <summary>
    /// Modelo de datos para una persona.
    /// </summary>
    public class PersonaModel : ObservableObject
    {
        /// <summary>
        /// Variable privada para almacenar el nombre de la persona.
        /// </summary>
        private string _nombre;

        /// <summary>
        /// Nombre de la persona.
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                RaisePropertyChanged("Nombre");
            }
        }

        /// <summary>
        /// Identificador de la persona.
        /// </summary>
        public Guid Id { get; set; }
    }
}
