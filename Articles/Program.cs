using System;
using System.Linq;

namespace Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

            Article article = new Article(input[0], input[1], input[2]);

            int commandNum = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandNum; i++)
            {
                string command = Console.ReadLine();

                string[] commandInputs = command.Split(": ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (commandInputs[0] == "Edit")
                {
                    string newContent = commandInputs[1];
                    article = article.EditContent(article, newContent);
                }
                else if (commandInputs[0] == "ChangeAuthor")
                {
                    string newAuthor = commandInputs[1];
                    article = article.ChangeAuthor(article, newAuthor);
                }
                else if (commandInputs[0] == "Rename")
                {
                    string newTitle = commandInputs[1];
                    article = article.RenameTitle(article, newTitle);
                }
            }

            Console.WriteLine(article);
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

        public Article EditContent(Article article, string newContent)
        {
            article.Content = newContent;
            return article;
        }

        public Article ChangeAuthor(Article article, string newAuthor)
        {
            article.Author = newAuthor;
            return article;
        }

        public Article RenameTitle(Article article, string newTitle)
        {
            article.Title = newTitle;
            return article;
        }
    }
}
