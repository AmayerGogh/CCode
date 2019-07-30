using Abp.Domain.Repositories;
using Amayer.Common;
using CCode.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CCode.Blogs
{
    public class ArticleManager : IArticleManager
    {

        private readonly IRepository<Article, long> _articleRepository;

        public ArticleManager(IRepository<Article, long> articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public void TestManager(Article article)
        {
            throw new NotImplementedException();
        }

        //领域代码

        public List<Expression<Func<Article, bool>>> GetListPredicate(BsTableRequestModel param)
        {
            var expressionList = Express.GetExpressionList<Article>();
         
            if (!string.IsNullOrWhiteSpace(param.search))
            {
                expressionList.Add(m => m.Title.Contains(param.search));
            }
            if (param.searches != null)
            {
                if (param.searches.ContainsKey("categoryId"))
                {
                    int cate = -1;
                    Int32.TryParse(param.searches["categoryId"], out cate);
                    if (cate > 0)
                    {
                        expressionList.Add(m => m.CategoryId == cate);
                    }
                }
            }
            return expressionList;
        }

    }
}
