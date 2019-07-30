using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CCode.Blogs.Dto
{
    /// <summary>
    /// 文章列表Dto
    /// </summary>

    public class ArticleListDto : EntityDto<long>
    {
        /// <summary></summary>
        public string Title { get; set; }
        /// <summary></summary>
        public long CategoryId { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreationTime { get; set; }
        /// <summary></summary>
        public string CategoryName { get; set; }
        /// <summary></summary>
        public List<ArticleListDto_Detail> ArticleDetail { get; set; }
    }
    /// <summary></summary>
    public class ArticleListDto_Detail
    {
        /// <summary></summary>
        public virtual long Id { get; set; }
        /// <summary></summary>
        public virtual bool IsDefault { get; set; }
        /// <summary></summary>
        public virtual long ArticleId { get; set; }


    }
}
