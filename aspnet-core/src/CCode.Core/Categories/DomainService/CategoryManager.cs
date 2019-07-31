

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
using CCode.Categories;


namespace CCode.Categories.DomainService
{
    /// <summary>
    /// Category领域层的业务管理
    ///</summary>
    public class CategoryManager :CCodeDomainServiceBase, ICategoryManager
    {
		
		private readonly IRepository<Category,long> _repository;

		/// <summary>
		/// Category的构造方法
		///</summary>
		public CategoryManager(
			IRepository<Category, long> repository
		)
		{
			_repository =  repository;
		}


		/// <summary>
		/// 初始化
		///</summary>
		public void InitCategory()
		{
			throw new NotImplementedException();
		}

		// TODO:编写领域业务代码



		 
		  
		 

	}
}
