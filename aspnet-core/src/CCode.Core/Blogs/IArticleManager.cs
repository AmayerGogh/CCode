using Abp.Domain.Services;
using CCode.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace CCode.Blogs
{
    public interface IArticleManager : IDomainService
    {
        void TestManager(Article article);

        List<Expression<Func<Article, bool>>> GetListPredicate(BsTableRequestModel param);
    }
}
