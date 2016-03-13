using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace CharlaMVVM.Common.Services
{
    /// <summary>
    /// Interfaz del servicio de navegación entre páginas.
    /// </summary>
    public interface INavigationService
    {
        event NavigatingCancelEventHandler Navigating;
        void NavigateTo(Type pageType);
        void GoBack();
    }
}
