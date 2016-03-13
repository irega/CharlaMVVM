using Windows.UI.Popups;
using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace CharlaMVVM.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public  partial class ViewBase : Page
    {
        public ViewBase()
        {
            this.InitializeComponent();

            //Evento de pulsación de la tecla "atrás" del teléfono.
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        /// <summary>
        /// Debemos controlar la pulsación de la tecla "atrás" del teléfono y gestionar su comportamiento manualmente
        /// después de implementar en la aplicación el servicio de navegación entre páginas.
        /// </summary>
        /// <param name="sender">Objeto que desencadena el evento.</param>
        /// <param name="e">Argumentos del evento.</param>
        protected virtual void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            //Si se puede ir hacia atrás...
            if (Frame.CanGoBack)
            {
                Frame.GoBack();

                //¡¡Esto es importante!! Decimos a la aplicación que hemos controlado el evento,..
                e.Handled = true;
            }
        }

        /// <summary>
        /// Método para mostrar un cuadro de diálogo en la vista con un mensaje.
        /// </summary>
        /// <param name="mensaje">Mensaje a mostar.</param>
        protected static async void MostarMensaje(string mensaje)
        {
            var dialog = new MessageDialog(mensaje, "CharlaMVVM");
            await dialog.ShowAsync();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }
    }
}
