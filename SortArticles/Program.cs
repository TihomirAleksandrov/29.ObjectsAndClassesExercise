using System;
using System.Linq;
using System.Collections.Generic;

namespace SortArticles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Article> articles = new List<Article>();

            int inputNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputNum; i++)
            {
                string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Article article = new Article(input[0], input[1], input[2]);

                articles.Add(article);
            }

            string criteria = Console.ReadLine();

            if (criteria == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (criteria == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (criteria == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }

    public class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }
        
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public override string ToString()
        {
            return $"{this.Title} - {this.Content}: {this.Author}";
        }
    }
}
