﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CCode.Blogs
{
    public class Article : FullAuditedEntity<long>// CreationAuditedEntity<long>
    {

        [Required]
        [MaxLength(20)]
        public virtual string Title { get; set; }

        public virtual string Description { get; set; }
        public virtual long CategoryId { get; set; }

        public virtual string Labels { get; set; }
        [DisplayName("封面")]
        public virtual long Cover { get; set; }
        public virtual int Type { get; set; } 
    }

    public enum EnumsArticleType
    {
        草稿 = 1,
        已发布 = 2
    }
}
