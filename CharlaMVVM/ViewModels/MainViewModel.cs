using CharlaMVVM.Common;
using CharlaMVVM.Common.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace CharlaMVVM.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Servicio de navegación entre vistas.
        /// </summary>
        private readonly INavigationService _navigationService;

        /// <summary>
        /// Constructor del modelo de vista.
        /// </summary>
        /// <param name="navigationService">Servicio de navegación entre vistas.
        /// Mediante la inyección de dependencias de MVVMLight, este parámetro nos viene
        /// con valor automáticamente.
        /// </param>
        public MainViewModel(INavigationService navigationService)
        {
            //Establecemos el servicio de navegación.
            _navigationService = navigationService;

            //Inicializamos los Commands.
            IrACommandBasicoCommand = new RelayCommand<Type>(p => IrAPagina(ViewModelLocator.CommandBasicoView));
            IrABindingBasicoCommand = new RelayCommand<Type>(p => IrAPagina(ViewModelLocator.BindingBasicoView));
            IrAEventToCommandCommand = new RelayCommand<Type>(p => IrAPagina(ViewModelLocator.EventToCommandView));
            IrAMessagingAvanzadoCommand = new RelayCommand<Type>(p => IrAPagina(ViewModelLocator.MessagingAvanzadoView));
        }

        /// <summary>
        /// Método para navegar a una página.
        /// </summary>
        public void IrAPagina(Type viewType)
        {
            //Llamamos al servicio de navegación.
            _navigationService.NavigateTo(viewType);
        }

        /// <summary>
        /// Command para navegar a la página de ejemplo de binding básico.
        /// </summary>
        public ICommand IrABindingBasicoCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command para navegar a la página de ejemplo de enlace evento-Command.
        /// </summary>
        public ICommand IrAEventToCommandCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command para navegar a la página de ejemplo básico de Commands.
        /// </summary>
        public ICommand IrACommandBasicoCommand
        {
            get;
            private set;
        }

        /// <summary>
        /// Command para navegar a la página de ejemplo avanzado de mensajes.
        /// </summary>
        public ICommand IrAMessagingAvanzadoCommand
        {
            get;
            private set;
        }
    }
}
