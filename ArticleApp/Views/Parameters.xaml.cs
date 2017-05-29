using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, voir la page http://go.microsoft.com/fwlink/?LinkId=234238

namespace ArticleApp.Views
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class Parameters : Page
    {
        public Parameters()
        {
            this.InitializeComponent();
        }

        private void LightOrDark_Toggled(object sender, RoutedEventArgs e)
        {
            var toggle = (ToggleSwitch)sender;
            ApplicationData.Current.LocalSettings.Values["LightOrDark"] = toggle.IsOn;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(MainPage));
        }
    }
}
