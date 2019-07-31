using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CCode.Blogs.Dto
{
    /// <summary>
    /// 文章编辑用Dto
    /// </summary>
    [AutoMap(typeof(Blogs.Article))]
    public class ArticleEditDto : IEntityDto<Nullable<long>>
    {
        /// <summary>
        ///   主键Id
        /// </summary>
        [DisplayName("主键Id")]
        public long? Id { get; set; }
        /// <summary></summary>
        [Required]
        [MaxLength(20)]
        [DisplayName("标题")]
        public string Title { get; set; }
        /// <summary></summary>
        public string Description { get; set; }
        /// <summary></summary>
        public string Cover { get; set; }
        /// <summary></summary>
        public long CategoryId { get; set; }


    }
    /// <summary></summary>
    [AutoMap(typeof(Blogs.Article))]
    public class ArticleForEditDto : ArticleEditDto
    {
        /// <summary></summary>
        public List<ArticleListDto_Detail> ArticleDetail { get; set; }

    }
}
