using NewspaperWebsite.Models;

namespace NewspaperWebsite.Repository
{
    public static class ArticleRepository
    {
        public static List<Article> _articles = new List<Article>()
        {
            new Article()
            {
                Id = 1,
                Title = "The best film ever made",
                Content = "This article described the scenario of the best film ever made, according to this journalist."
            },
            new Article()
            {
                Id = 2,
                Title = "The greatest film of all time",
                Content = "This article make the vindication of the greatest film of all time, according to this journalist."
            },
            new Article()
            {
                Id = 3,
                Title = "The most astonishing film you will ever see",
                Content = "This article praises the most astonishing film you will ever see."
            }
        };

        public static List<Article> GetArticles() => _articles;

        public static Article? GetArticleById(int articleId)
        {
            return _articles.Find(article => article.Id == articleId);
        }

        public static void AddArticle(string title, string content)
        {
            int IdnewArticle = _articles.Max(article => article.Id) + 1;

            var newArticle = new Article()
            {
                Id = IdnewArticle,
                Title = title,
                Content = content
            };

            _articles.Add(newArticle);
        }

        public static void UpdateArticle(Article articleToUpdate)
        {
            Article? article = _articles.Find(article => article.Id == articleToUpdate.Id);

            if (article is null) return;

            article.Title = articleToUpdate.Title;
            article.Content = articleToUpdate.Content;
        }

        public static void DeleteArticle(int articleId)
        {
            Article? article = _articles.Find(article => article.Id == articleId);

            if (article is null) return;

            _articles.Remove(article);
        }
    }
}
