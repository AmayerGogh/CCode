using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCode.Blogs
{
    public class ArticleLabel : Entity<long>
    {        
        public string Name { get; set; }
    }
}
