

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using CCode.Categories;


namespace CCode.Categories.DomainService
{
    public interface ICategoryManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitCategory();



		 
      
         

    }
}
