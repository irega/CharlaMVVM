using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace CharlaMVVM.Common.Services
{
    /// <summary>
    /// Implementación de servicio de navegación entre páginas según el creador de MVVMLight:
    /// http://blog.galasoft.ch/posts/2011/01/navigation-in-a-wp7-application-with-mvvm-light/
    /// </summary>
    public class NavigationService : INavigationService
    {
        //Frame principal de la aplicación.
        private Frame _mainFrame;

        public event NavigatingCancelEventHandler Navigating;

        public void NavigateTo(Type pageType)
        {
            if (EnsureMainFrame())
            {
                _mainFrame.Navigate(pageType);
            }
        }

        public void GoBack()
        {
            if (EnsureMainFrame()
                && _mainFrame.CanGoBack)
            {
                _mainFrame.GoBack();
            }
        }

        private bool EnsureMainFrame()
        {
            if (_mainFrame != null)
            {
                return true;
            }

            //Obtenemos el frame principal de la aplicación.
            var app = App.Current as CharlaMVVM.App;
            _mainFrame = app.MainFrame;

            if (_mainFrame != null)
            {
                // Could be null if the app runs inside a design tool
                _mainFrame.Navigating += (s, e) =>
                {
                    if (Navigating != null)
                    {
                        Navigating(s, e);
                    }
                };

                return true;
            }

            return false;
        }
    }
}
