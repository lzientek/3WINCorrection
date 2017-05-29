using System;
using System.Linq;
using ArticleApp.AppData;

namespace ArticleApp.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Group Group { get; set; }

        public string Title { get; set; }

        public Uri Link { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public string Copyright { get; set; }

        public Category(int id, string name, int groupId)
        {
            Id = id;
            Name = name;
            Group = GroupProvider.Groups.Single(group => group.Id == groupId);
        }
    }
}
