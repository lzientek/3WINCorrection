using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArticleApp.Models;

namespace ArticleApp.AppData
{
    public static class GroupProvider
    {
        public static List<Group> Groups = new List<Group>()
        {
            new Group(1, "Développement", '\xE943', "#1abc9c"),
            new Group(2, "Organisation", '\xE825', "#e67e22"),
            new Group(3, "Système et Réseau", '\xE17B', "#3498db"),
            new Group(4, "Bas niveau", '\xE74C', "#9b59b6"),
            new Group(5, "Gestion de données", '\xE81E', "#e74c3c")
        };
    }

    public static class CategoryProvider
    {
        public static List<Category> Categories = new List<Category>()
                {
                    new Category(1, "Securité", 4),
                    new Category(2, "Maths & Algo", 4),
                    new Category(3, "Réseaux", 3),
                    new Category(4, "Management", 2),
                    new Category(5, "Gestion de Projets", 2),
                    new Category(6, "Jeux Vidéo", 1),
                    new Category(7, "Java", 1),
                    new Category(8, "Web", 1),
                    new Category(9, "Dev .NET", 1),
                    new Category(10, "Fondamentaux", 4),
                    new Category(11, "Apple", 3),
                    new Category(12, "Base de données", 5),
                    new Category(13, "Mobilité", 1),
                    new Category(14, "Microsoft", 3),
                    new Category(15, "Business Intel", 5),
                    new Category(16, "Robotique", 4),
                    new Category(17, "Linux", 3),
                    new Category(18, "C/C++", 4),
                    new Category(19, "Infrastructure", 3)
                }
            ;

        public static List<Category> GetCategories(Group g)
        {
            return Categories.Where(c => c.Group.Id == g.Id).ToList();
        }
        public static List<Category> GetCategories(int groupId)
        {
            return Categories.Where(c => c.Group.Id == groupId).ToList();
        }
        public static List<Category> GetDevelopmentCategories()
        {
            return GetCategories(1);
        }
        public static List<Category> GetOrganizationCategories()
        {
            return GetCategories(2);
        }
        public static List<Category> GetNetworksCategories()
        {
            return GetCategories(3);
        }
        public static List<Category> GetLowLevelCategories()
        {
            return GetCategories(4);
        }
        public static List<Category> GetDataCategories()
        {
            return GetCategories(5);
        }
    }
}
