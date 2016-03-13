using Windows.UI.Xaml.Controls;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236
using CharlaMVVM.Common.Messages.EditarPersonaMessages;
using GalaSoft.MvvmLight.Messaging;

namespace CharlaMVVM.Views.UserControls
{
    public sealed partial class EditarPersonaUc : UserControl
    {
        public EditarPersonaUc()
        {
            this.InitializeComponent();

            //Cuando recibimos desde el modelo de vista que los datos ya han sido validados...
            Messenger.Default.Register<DatosPersonaListosMessage>(this, 

                //Debemos notificar a la vista "padre" con los datos actualizados.
                (msg) => Messenger.Default.Send(new DatosPersonaProcesadosMessage(msg.AccionAceptar, msg.NombrePersona)));
        }
    }
}
