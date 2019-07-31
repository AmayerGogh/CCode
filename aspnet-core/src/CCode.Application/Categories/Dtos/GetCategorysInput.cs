
using Abp.Runtime.Validation;
using CCode.Dtos;
using CCode.Categories;

namespace CCode.Categories.Dtos
{
    public class GetCategorysInput : PagedSortedAndFilteredInputDto, IShouldNormalize
    {

        /// <summary>
        /// 正常化排序使用
        /// </summary>
        public void Normalize()
        {
            if (string.IsNullOrEmpty(Sorting))
            {
                Sorting = "Id";
            }
        }

    }
}
