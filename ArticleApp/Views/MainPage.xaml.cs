using Windows.UI.Xaml.Controls;
using ArticleApp.ViewModels;
using Windows.UI.Xaml;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ArticleApp.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            var ligthOrDark = (bool?) ApplicationData.Current.LocalSettings.Values["LightOrDark"];
            if(ligthOrDark == null || ligthOrDark == false)
            {
                VisualStateManager.GoToState(this, "State1", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "State2", false);
            }
        }

        public MainPageViewModel ViewModel
        {
            get
            {
                return (MainPageViewModel)DataContext;
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(Parameters));
        }
    }
}
