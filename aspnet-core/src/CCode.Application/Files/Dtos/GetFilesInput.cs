
using Abp.Runtime.Validation;
using CCode.Dtos;
using CCode.Files;

namespace CCode.Files.Dtos
{
    public class GetFilesInput : PagedSortedAndFilteredInputDto, IShouldNormalize
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
