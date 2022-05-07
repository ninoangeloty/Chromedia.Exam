using Chromedia.Application.Article.Queries;
using Chromedia.Infrastructure.Domain;
using Chromedia.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace Chromedia.Tests.HandlerTests
{
    [TestClass]
    public class GetArticlesQueryHandlerTests
    {
        [TestMethod]
        public async Task GetArticlesQueryHandler_ReturnOrderedArticlesWithValidTitle()
        {
            var articles = new[] { new ArticleDetail { Title = "A", NumberOfComments = 100 }, new ArticleDetail { NumberOfComments = 200 }, new ArticleDetail { Title = "C", NumberOfComments = 300 } };

            var returnValue = Task.FromResult((IList<ArticleDetail>)articles.ToList());
            var articleServiceMock = new Mock<IArticleService>();
            articleServiceMock.Setup(_ => _.GetArticles()).Returns(returnValue);

            var handler = new GetArticlesQueryHandler(articleServiceMock.Object);
            var result = await handler.Handle(new GetArticlesQuery(2), CancellationToken.None);

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0], "C");
            Assert.AreEqual(result[1], "A");
        }

        [TestMethod]
        public async Task GetArticlesQueryHandler_ReturnOrderedArticlesUsingLimit()
        {
            var articles = new[] { new ArticleDetail { Title = "A", NumberOfComments = 100 }, new ArticleDetail { Title = "B", NumberOfComments = 200 }, new ArticleDetail { Title = "C", NumberOfComments = 300 } };
            
            var returnValue = Task.FromResult((IList<ArticleDetail>)articles.ToList());
            var articleServiceMock = new Mock<IArticleService>();
            articleServiceMock.Setup(_ => _.GetArticles()).Returns(returnValue);

            var handler = new GetArticlesQueryHandler(articleServiceMock.Object);
            var result = await handler.Handle(new GetArticlesQuery(2), CancellationToken.None);

            Assert.AreEqual(result.Length, 2);
            Assert.AreEqual(result[0], "C");
            Assert.AreEqual(result[1], "B");
        }

        [TestMethod]
        public async Task GetArticlesQueryHandler_ThrowExceptionWhenLimitIsNotValid()
        {
            var articles = new[] { new ArticleDetail { Title = "A", NumberOfComments = 100 }, new ArticleDetail { Title = "B", NumberOfComments = 200 }, new ArticleDetail { Title = "C", NumberOfComments = 300 } };

            var returnValue = Task.FromResult((IList<ArticleDetail>)articles.ToList());
            var articleServiceMock = new Mock<IArticleService>();
            articleServiceMock.Setup(_ => _.GetArticles()).Returns(returnValue);

            var handler = new GetArticlesQueryHandler(articleServiceMock.Object);

            await Assert.ThrowsExceptionAsync<ArgumentException>(async () => await handler.Handle(new GetArticlesQuery(-1), CancellationToken.None));
        }
    }
}
