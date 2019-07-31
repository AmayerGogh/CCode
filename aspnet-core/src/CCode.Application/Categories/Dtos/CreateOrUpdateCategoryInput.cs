

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CCode.Categories;

namespace CCode.Categories.Dtos
{
    public class CreateOrUpdateCategoryInput
    {
        [Required]
        public CategoryEditDto Category { get; set; }

    }
}