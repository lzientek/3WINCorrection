using System;

namespace ArticleApp.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Uri Link { get; set; }

        public DateTime PubDate { get; set; }

        public Category Category { get; set; }
    }
}
