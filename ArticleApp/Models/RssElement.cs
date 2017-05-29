using System;
using System.Collections.Generic;

namespace ArticleApp.Models
{
    public class RssElement
    {
        public Uri EndPoint { get; set; }

        public Category Category { get; set; }

        public List<Article> Articles { get; set; }
    }
}
