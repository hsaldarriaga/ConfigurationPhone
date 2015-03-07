using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml.Shapes;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// La plantilla de elemento Página en blanco está documentada en http://go.microsoft.com/fwlink/?LinkId=391641

namespace ConfigurationPhone
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
        }
        private void Initialize()
        {
            double width = this.ActualWidth;
            double height = this.ActualHeight;
            SetPolygon(ref tri1, new Point(0, 0), new Point(0, width), new Point(width, 0));
            SetPolygon(ref tri2, new Point(width, 0), new Point(width/2, width/2), new Point(width, width));
            SetPolygon(ref tri3, new Point(0, height), new Point(width / 2, width / 2), new Point(width, width));
            SetPolygon(ref tri4, new Point(0, width), new Point(width / 2, width / 2), new Point(0, height));
            SetPolygon(ref tri5, new Point(0, height), new Point(width, width), new Point(width, height));
            
        }

        private void SetTextBlock()
        {
            var setting = Windows.Storage.ApplicationData.Current.LocalSettings;
            if (setting.Values["large"] == null)
            {
                setting.Values["large"] = Resources["TextStyleLargeFontSize"].ToString();
                setting.Values["medium"] = Resources["TextStyleMediumFontSize"].ToString();
                setting.Values["control"] = Resources["ContentControlFontSize"].ToString();
                setting.Values["small"] = Resources["TextStyleSmallFontSize"].ToString();
                setting.Values["extra"] = Resources["TextStyleExtraLargeFontSize"].ToString();
            }
            else
            {
                tex1.FontSize = Convert.ToDouble(setting.Values["large"].ToString());
                tex2.FontSize = Convert.ToDouble(setting.Values["extra"].ToString());
                tex3.FontSize = Convert.ToDouble(setting.Values["control"].ToString());
                tex4.FontSize = Convert.ToDouble(setting.Values["small"].ToString());
                tex5.FontSize = Convert.ToDouble(setting.Values["medium"].ToString()); 
                
            }
        }

        private void SetPolygon(ref Polygon Poly, Point one, Point two, Point three)
        {
            Point Point1 = one;
            Point Point2 = two;
            Point Point3 = three;
            PointCollection myPointCollection = new PointCollection();
            myPointCollection.Add(Point1);
            myPointCollection.Add(Point2);
            myPointCollection.Add(Point3);
            Poly.Points = myPointCollection;
            SetTextBlock();
        }

        private void SetPositionTextBlock()
        {
            double width = this.ActualWidth;
            double height = this.ActualHeight;
            Canvas.SetLeft(tex1, (width/3d) - (tex1.ActualWidth/2d));
            Canvas.SetTop(tex1, (width/3d) - (tex1.ActualHeight / 2d));
            
            Canvas.SetLeft(tex2, (5d * width / 6d) - (tex2.ActualWidth / 2d));
            Canvas.SetTop(tex2, (width / 2d) - (tex2.ActualHeight / 2d));
            
            Canvas.SetLeft(tex4, (width / 9d) - (tex4.ActualWidth / 2d));
            Canvas.SetTop(tex4, ((3d * width / 2d) + height) / 3d - (tex4.ActualHeight / 2d));

            Canvas.SetLeft(tex3, (width / 2d) - (tex3.ActualWidth / 2d));
            Canvas.SetTop(tex3, (((3d * width / 2d) + height) / 3d) - (tex3.ActualHeight / 2d));

            Canvas.SetLeft(tex5, (2d * width / 3d) - (tex5.ActualWidth / 2d));
            Canvas.SetTop(tex5, ((width + 2d * height) / 3d) - (tex5.ActualHeight / 2d));
        }
        /// <summary>
        /// Se invoca cuando esta página se va a mostrar en un objeto Frame.
        /// </summary>
        /// <param name="e">Datos de evento que describen cómo se llegó a esta página.
        /// Este parámetro se usa normalmente para configurar la página.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Preparar la página que se va a mostrar aquí.

            // TODO: Si la aplicación contiene varias páginas, asegúrese de
            // controlar el botón para retroceder del hardware registrándose en el
            // evento Windows.Phone.UI.Input.HardwareButtons.BackPressed.
            // Si usa NavigationHelper, que se proporciona en algunas plantillas,
            // el evento se controla automáticamente.
        }

        private void Canvas_LayoutUpdated(object sender, object e)
        {
            SetPositionTextBlock();
        }

        private void Canvas_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(SettingPage));
        }
    }
}
