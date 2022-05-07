using Chromedia.Infrastructure.Domain;
using Chromedia.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Chromedia.Infrastructure.Services
{
    public class ArticleService : IArticleService
    {
        private readonly string _apiUri = "https://jsonmock.hackerrank.com/api";

        public async Task<IList<ArticleDetail>> GetArticles()
        {
            var dataList = new List<ArticleDetail>();
            var articles = await HttpHelper.GetAsync<Article>(GetUri("articles", "page=1"));
            dataList.AddRange(articles.Data);

            for (int page = 1; page < articles.TotalPages; page++)
            {
                var article = await HttpHelper.GetAsync<Article>(GetUri("articles", $"page={page + 1}"));
                dataList.AddRange(article.Data);
            }

            return dataList;
        }

        private string GetUri(string path, string query)
        {
            return $"{_apiUri}/{path}?{query}";
        }
    }
}
