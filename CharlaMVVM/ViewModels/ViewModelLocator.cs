using CharlaMVVM.Common;
using CharlaMVVM.Common.Services;
using CharlaMVVM.Views;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using System;

namespace CharlaMVVM.ViewModels
{
    /// <summary>
    /// Localizador de modelos de vista.
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //Registramos el servicio de navegación entre vistas.
            SimpleIoc.Default.Register<INavigationService, NavigationService>();

            //Registramos los modelos de vista de la aplicación.
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<CommandBasicoViewModel>();
            SimpleIoc.Default.Register<BindingBasicoViewModel>();
            SimpleIoc.Default.Register<EventToCommandViewModel>();
            SimpleIoc.Default.Register<MessagingAvanzadoViewModel>();
            SimpleIoc.Default.Register<EditarPersonaViewModel>();
        }

        #region Tipos de vistas

        /*
         * Centralizamos aquí los tipos de vistas para que el servicio de navegación conozca
         * las vistas existentes en la aplicación.
         */

        /// <summary>
        /// Vista de ejemplo básico de uso de Commands.
        /// </summary>
        public static readonly Type CommandBasicoView = typeof(CommandBasicoView);

        /// <summary>
        /// Vista de ejemplo básico de Binding.
        /// </summary>
        public static readonly Type BindingBasicoView = typeof(BindingBasicoView);

        /// <summary>
        /// Vista de ejemplo de enlace evento-Command.
        /// </summary>
        public static readonly Type EventToCommandView = typeof(EventToCommandView);

        /// <summary>
        /// Vista de ejemplo avanzado de uso de mensajes.
        /// </summary>
        public static readonly Type MessagingAvanzadoView = typeof(MessagingAvanzadoView);

        #endregion

        #region Main

        /// <summary>
        /// Modelo de vista para la vista principal de la aplicación.
        /// </summary>
        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        #endregion

        #region CommandBasico

        /// <summary>
        /// Modelo de vista para ejemplo de uso básico de Commands.
        /// </summary>
        public CommandBasicoViewModel CommandBasico
        {
            get
            {
                return ServiceLocator.Current.GetInstance<CommandBasicoViewModel>();
            }
        }

        #endregion

        #region BindingBasico

        /// <summary>
        /// Modelo de vista para ejemplo básico de Binding.
        /// </summary>
        public BindingBasicoViewModel BindingBasico
        {
            get
            {
                return ServiceLocator.Current.GetInstance<BindingBasicoViewModel>();
            }
        }

        #endregion

        #region MessagingAvanzado

        /// <summary>
        /// Modelo de vista para la vista de ejemplo avanzado de uso de mensajes.
        /// </summary>
        public MessagingAvanzadoViewModel MessagingAvanzado
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MessagingAvanzadoViewModel>();
            }
        }

        #endregion

        #region EventToCommand

        /// <summary>
        /// Modelo de vista para la vista de ejemplo de enlace evento-Command.
        /// </summary>
        public EventToCommandViewModel EventToCommand
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EventToCommandViewModel>();
            }
        }

        #endregion

        #region EditarPersona

        /// <summary>
        /// Modelo de vista para el popup de edición de datos de la persona.
        /// </summary>
        public EditarPersonaViewModel EditarPersona
        {
            get
            {
                return ServiceLocator.Current.GetInstance<EditarPersonaViewModel>();
            }
        }

        #endregion
    }
}
