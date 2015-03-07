using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkID=390556

namespace ConfigurationPhone
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
        public SettingPage()
        {
            this.InitializeComponent();
            HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            Initialize();
        }

        void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (this is SettingPage)
            {
                var setting = Windows.Storage.ApplicationData.Current.LocalSettings;
                if (tx1.Text!="")
                    setting.Values["large"] = tx1.Text;
                if (tx2.Text != "")
                    setting.Values["extra"] = tx2.Text;
                setting.Values["control"] = tx3.SelectedIndex;
                if (tx4.Text != "")
                    setting.Values["small"] = tx4.Text;
                if (tx5.Text != "")
                    setting.Values["medium"] = tx5.Text;
            }
            Frame frame = Window.Current.Content as Frame;
            if (frame == null)
            {
                return;
            }

            if (frame.CanGoBack)
            {
                frame.GoBack();
                e.Handled = true;
            }
        }

        private void Initialize()
        {
            var setting = Windows.Storage.ApplicationData.Current.LocalSettings;
            tx1.Text = setting.Values["large"].ToString();
            tx2.Text = setting.Values["extra"].ToString();
            tx3.SelectedIndex = int.Parse(setting.Values["control"].ToString());
            tx4.Text = setting.Values["small"].ToString();
            tx5.Text = setting.Values["medium"].ToString();
        }

        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
        }

        private void Button_Tapped(object sender, TappedRoutedEventArgs e)
        {
            tx1.Text = "Hernan";
            tx5.Text = Resources["TextStyleMediumFontSize"].ToString();
            tx3.SelectedIndex = 0;
            tx4.Text = Resources["TextStyleSmallFontSize"].ToString();
            tx2.Text = "20";
        }
    }
}
