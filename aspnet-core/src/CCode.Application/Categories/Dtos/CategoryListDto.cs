

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using CCode.Categories;

namespace CCode.Categories.Dtos
{
    public class CategoryListDto : EntityDto<long> 
    {

        
		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// ParentId
		/// </summary>
		public long ParentId { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		public int Status { get; set; }



		/// <summary>
		/// Sort
		/// </summary>
		public int Sort { get; set; }



		/// <summary>
		/// Mark
		/// </summary>
		public string Mark { get; set; }



		/// <summary>
		/// Icon
		/// </summary>
		public string Icon { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		public int Type { get; set; }




    }
}