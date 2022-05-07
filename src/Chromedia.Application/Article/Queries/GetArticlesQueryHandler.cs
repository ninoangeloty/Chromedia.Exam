using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Chromedia.Infrastructure.Services;
using MediatR;
using System.Linq;

namespace Chromedia.Application.Article.Queries
{
    public class GetArticlesQueryHandler : IRequestHandler<GetArticlesQuery, string[]>
    {
        private readonly IArticleService _articleService;

        public GetArticlesQueryHandler(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public async Task<string[]> Handle(GetArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleService.GetArticles();

            if (request.Limit < 1)
            {
                throw new ArgumentException("Value of limit should be greater than zero.");
            }

            var articleTitles = articles
                .Where(_ => !string.IsNullOrEmpty(_.Title) || !string.IsNullOrEmpty(_.StoryTitle))
                .OrderByDescending(_ => _.NumberOfComments)
                .ThenByDescending(_ => _.Title)
                .Take(request.Limit)
                .Select(_ => _.Title ?? _.StoryTitle);

            return articleTitles.ToArray();
        }
    }
}
