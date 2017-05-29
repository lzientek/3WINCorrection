using System;
using System.Linq;
using Windows.UI.Xaml.Media;

namespace ArticleApp.Models
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public char Icon { get; set; }

        public SolidColorBrush Color { get; set; }

        public Group(int id, string name, char icon, string color)
        {
            Id = id;
            Name = name;
            Icon = icon;

            //var hex = color.Replace("#", "");
            //var bytes = Enumerable.Range(0, hex.Length)
            //         .Where(x => x % 2 == 0)
            //         .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
            //         .ToArray();
            //Color = new SolidColorBrush(Windows.UI.Color.FromArgb(255, bytes[2], bytes[1], bytes[0]));
        }
    }
}
