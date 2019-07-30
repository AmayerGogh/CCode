using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCode.Blogs.Dto
{
    [AutoMapFrom(typeof(Blogs.ArticleDetail))]
    class ArticleLabelDto
    {
        /// <summary></summary>
        public long Id { get; set; }
        /// <summary></summary>
        public string Name { get; set; }
    }
}
