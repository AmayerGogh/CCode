using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCode.Blogs
{
    public class ArticleDetail : Entity<long>
    {        
        public virtual long ArticleId { get; set; }
        public virtual string Body { get; set; }
        public virtual bool IsDefault { get; set; }
        public virtual int Type { get; set; }

        public ArticleDetail()
        {

        }
        public ArticleDetail(long _ArticleId)
        {
            ArticleId = _ArticleId;
            Type = (int)EnumArticleDetailType.html;
            IsDefault = true;
        }



    }

    public enum EnumArticleDetailType
    {
        html = 1,
        md = 2
    }
}
