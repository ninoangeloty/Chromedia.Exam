using Chromedia.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Chromedia.Infrastructure.Services
{
    public interface IArticleService
    {
        Task<IList<ArticleDetail>> GetArticles();
    }
}
