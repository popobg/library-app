using Microsoft.AspNetCore.Mvc;
using NewspaperWebsite.Models;
using NewspaperWebsite.Models.ViewModels;
using NewspaperWebsite.Repository;

namespace NewspaperWebsite.Controllers
{
    public class ArticleController : Controller
    {
        [HttpGet]
        public IActionResult List()
        {
            return View(ArticleRepository.GetArticles());
        }

        [HttpGet]
        public IActionResult Details(int ArticleId)
        {
            return View(ArticleRepository.GetArticleById(ArticleId));
        }

        [HttpGet]
        public IActionResult Edit(int ArticleId)
        {
            var article = ArticleRepository.GetArticleById(ArticleId);

            if (article == null) return RedirectToAction("List", "Article");

            return View(article);
        }

        [HttpPost]
        public IActionResult Edit(int articleId, Article article)
        {
            if (articleId != article.Id) return BadRequest();

            if (!String.IsNullOrEmpty(article.Title) && !String.IsNullOrEmpty(article.Content))
            {
                var articleToUpdate = new Article()
                {
                    Id = article.Id,
                    Title = article.Title,
                    Content = article.Content,
                };

                ArticleRepository.UpdateArticle(articleToUpdate);
            }

            return RedirectToAction("List", "Article");
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddArticle articleAdded)
        {
            // check if any returned value is empty
            if (!String.IsNullOrEmpty(articleAdded.Title) && !String.IsNullOrEmpty(articleAdded.Content))
            {
                ArticleRepository.AddArticle(articleAdded.Title, articleAdded.Content);
            }

            return RedirectToAction("List", "Article");
        }

        [HttpGet]
        public IActionResult Delete(int articleId)
        {
            ArticleRepository.DeleteArticle(articleId);

            return RedirectToAction("List", "Article");
        }
    }
}