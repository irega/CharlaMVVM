using GalaSoft.MvvmLight.Messaging;
using System;

namespace CharlaMVVM.Common.Messages.EditarPersonaMessages
{
    /// <summary>
    /// Mensaje para que el modelo de vista pida a la vista los datos actualizados de una persona.
    /// </summary>
    /// <remarks>
    /// VM. Padre -> V. Padre
    /// </remarks>
    public class ObtenerDatosPersonaMessage : MessageBase { }

    /// <summary>
    /// Mensaje para que el modelo de la vista "hija" notifique a dicha vista de que los datos de la persona ya han sido validados.
    /// </summary>
    /// <remarks>
    /// VM. Hija -> V. Hija
    /// </remarks>
    public class DatosPersonaListosMessage : MessageBase
    {
        public DatosPersonaListosMessage(bool accionAceptar, string nombrePersona)
        {
            this.AccionAceptar = accionAceptar;
            this.NombrePersona = nombrePersona;
        }
        public bool AccionAceptar { get; set; }
        public string NombrePersona { get; set; }
    }

    /// <summary>
    /// Mensaje para que la vista "hija" notifique a la vista "padre" de que los datos de la persona ya han sido procesados.
    /// </summary>
    /// <remarks>
    /// V. Hija -> V. Padre
    /// </remarks>
    public class DatosPersonaProcesadosMessage : DatosPersonaListosMessage
    {
        public DatosPersonaProcesadosMessage(bool accionAceptar, string nombrePersona)
            : base(accionAceptar, nombrePersona)
        {
        }
    }

    /// <summary>
    /// Mensaje para que la vista "padre" notifique a su modelo de vista de que los datos de la persona ya están listos para guardar.
    /// </summary>
    /// <remarks>
    /// V. Padre -> VM. Padre
    /// </remarks>
    public class GuardarDatosPersonaMessage : DatosPersonaListosMessage
    {
        public GuardarDatosPersonaMessage(bool accionAceptar, string nombrePersona)
            : base(accionAceptar, nombrePersona)
        {
        }
    }
}
