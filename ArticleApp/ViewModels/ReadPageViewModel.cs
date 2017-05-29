using System;
using ArticleApp.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace ArticleApp.ViewModels
{
    public class ReadPageViewModel : ViewModelBase
    {
        private Article _article;

        public Article Article
        {
            get { return _article; }
            set
            {
                _article = value;
                RaisePropertyChanged();
            }
        }

        public ReadPageViewModel()
        {
            ViewOnSiteCommand = new RelayCommand(ExecuteViewOnSiteCommand);
        }

        public RelayCommand ViewOnSiteCommand { get; }

        private async void ExecuteViewOnSiteCommand()
        {
            await Windows.System.Launcher.LaunchUriAsync(Article.Link);
        }
    }
}
