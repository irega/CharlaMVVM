using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641
using CharlaMVVM.Common.Messages.EditarPersonaMessages;
using CharlaMVVM.Views.UserControls;
using GalaSoft.MvvmLight.Messaging;

namespace CharlaMVVM.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MessagingAvanzadoView : ViewBase
    {
        /// <summary>
        /// Popup para edición de datos de una persona.
        /// </summary>
        private Popup _edicionPersonaPopup;

        /// <summary>
        /// Sobreescribimos el comportamiento de la tecla atrás para poder cerrar el popup si está abierto.
        /// </summary>
        /// <param name="sender">Objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected override void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            //Si el popup está abierto, lo cerramos antes.
            if (_edicionPersonaPopup != null && _edicionPersonaPopup.IsOpen)
            {
                _edicionPersonaPopup.IsOpen = false;
            }

            //Comportamiento normal.
            base.HardwareButtons_BackPressed(sender, e);
        }

        public MessagingAvanzadoView()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;

            //Escuchamos mensajes que nos pidan abrir el popup de edición de una persona.
            Messenger.Default.Register<ObtenerDatosPersonaMessage>(this, (msg) => ShowEditarPersonaPopup());
        }

        /// <summary>
        /// Muestra el popup de edición de los datos de una persona.
        /// </summary>
        private void ShowEditarPersonaPopup()
        {
            //Si es la primera vez que se abre el popup, lo configuramos.
            if (_edicionPersonaPopup == null)
            {
                var positionPopup = new Thickness {Bottom = 20.0, Left = 15.0, Top = 270, Right = 20.0};
                _edicionPersonaPopup = new Popup
                {
                    Height = 400,
                    Width = 400,
                    Margin = positionPopup
                };

                //Añadimos la vista de edición de una persona al popup.
                var control = new EditarPersonaUc();

                //Nos suscribimos al evento correspondiente para que la vista "hija" nos notifique
                //cuando debemos cerrar el popup y pasar el mensaje final al modelo de vista.
                Messenger.Default.Register<DatosPersonaProcesadosMessage>(this, (msg) =>
                {
                    //Cerramos el popup.
                    _edicionPersonaPopup.IsOpen = false;

                    //Notificamos al modelo de vista de la vista "padre" para que guarde los datos en la persona.
                    Messenger.Default.Send(new GuardarDatosPersonaMessage(msg.AccionAceptar, msg.NombrePersona));
                });

                _edicionPersonaPopup.Child = control;
            }
            else
            {
                //TODO: Limpiar el nombre mostrado en el popup antes de abrirlo.
                //O utilizamos mensajes para limpiar los datos....
                //...o destruimos y volvemos a instanciar el popup. ¿Limpiar regitro de mensajes antes de destroy?
            }

            //Mostramos popup si no está ya abierto.
            if (!_edicionPersonaPopup.IsOpen)
            {
                _edicionPersonaPopup.IsOpen = true;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }
    }
}
