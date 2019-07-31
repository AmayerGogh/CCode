

using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Abp.Linq;
using Abp.Linq.Extensions;
using Abp.Extensions;
using Abp.UI;
using Abp.Domain.Repositories;
using Abp.Domain.Services;

using CCode;
using CCode.Files;


namespace CCode.Files.DomainService
{
    /// <summary>
    /// File领域层的业务管理
    ///</summary>
    public class FileManager :CCodeDomainServiceBase, IFileManager
    {
		
		private readonly IRepository<File,long> _repository;

		/// <summary>
		/// File的构造方法
		///</summary>
		public FileManager(
			IRepository<File, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitFile()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
