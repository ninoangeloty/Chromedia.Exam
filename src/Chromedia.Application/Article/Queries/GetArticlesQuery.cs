using MediatR;
using System;

namespace Chromedia.Application.Article.Queries
{
    public class GetArticlesQuery : IRequest<string[]>
    {
        public GetArticlesQuery(int limit)
        {
            Limit = limit;
        }

        public int Limit { get; set; }
    }
}
