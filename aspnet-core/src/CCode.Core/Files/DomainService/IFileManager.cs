

using System;
using System.Threading.Tasks;
using Abp;
using Abp.Domain.Services;
using CCode.Files;


namespace CCode.Files.DomainService
{
    public interface IFileManager : IDomainService
    {

        /// <summary>
        /// 初始化方法
        ///</summary>
        void InitFile();



		 
      
         

    }
}
