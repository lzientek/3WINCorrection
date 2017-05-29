using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ArticleApp.AppData;
using ArticleApp.Models;
using ArticleApp.Views;
using GalaSoft.MvvmLight;

namespace ArticleApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        #region Fields

        private const string ARTICLE_URI = "https://www.supinfo.com/api/supinfo?action=rss&tags={0}";
        private const string ID_PATTERN = "https://www.supinfo.com/articles/single/";

        private ObservableCollection<Article> _articles;
        private List<RssElement> _elements;

        #endregion

        #region Properties

        public ObservableCollection<Article> Articles
        {
            get
            {
                return _articles;
            }
            set
            {
                _articles = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public MainPageViewModel()
        {
            _elements = new List<RssElement>();
            Articles = new ObservableCollection<Article>();
            Start();
        }

        #endregion

        #region Handled Methods

        public void ListViewBase_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var frame = (Frame)Window.Current.Content;
            frame.Navigate(typeof(ReadPage), e.ClickedItem);
        }

        #endregion

        #region Methods

        private void Start()
        {
            foreach (var category in CategoryProvider.Categories)
            {
                Fetch(category);
            }
        }

        private async Task Fetch(Category category)
        {
            var rssElement = new RssElement
            {
                Category = category,
                EndPoint = new Uri(string.Format(ARTICLE_URI, category.Id))
            };

            try
            {
                var xmlDocument = await XmlDocument.LoadFromUriAsync(rssElement.EndPoint);
                var channelNode = xmlDocument.LastChild?.SelectSingleNode("channel");

                if (channelNode != null)
                {
                    rssElement.Category.Title = channelNode.SelectSingleNode("title")?.InnerText;
                    rssElement.Category.Copyright = channelNode.SelectSingleNode("copyright")?.InnerText;
                    rssElement.Category.Language = channelNode.SelectSingleNode("language")?.InnerText;
                    rssElement.Category.Description = channelNode.SelectSingleNode("description")?.InnerText;
                    rssElement.Category.Link = new Uri(channelNode.SelectSingleNode("link")?.InnerText);

                    rssElement.Articles = new List<Article>();

                    foreach (var item in channelNode.SelectNodes("item"))
                    {
                        var article = new Article
                        {
                            Category = rssElement.Category,
                            Title = item.SelectSingleNode("title")?.InnerText,
                            Description = item.SelectSingleNode("description")?.InnerText,
                            Link = new Uri(item.SelectSingleNode("link")?.InnerText),
                            PubDate = DateTime.Parse(item.SelectSingleNode("pubDate")?.InnerText)
                        };

                        article.Id = int.Parse(article.Link.ToString().Replace(ID_PATTERN, string.Empty).Split('-').First());

                        rssElement.Articles.Add(article);

                        if (!Articles.Any(a => a.Link.Equals(article.Link)))
                        {
                            Articles.Add(article);
                        }
                    }

                    _elements.Add(rssElement);
                }
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
            }
        }

        #endregion
    }
}
