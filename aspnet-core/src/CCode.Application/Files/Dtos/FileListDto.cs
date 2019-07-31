

using System;
using Abp.Application.Services.Dto;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using CCode.Files;

namespace CCode.Files.Dtos
{
    public class FileListDto : EntityDto<long> 
    {

        
		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }



		/// <summary>
		/// Size
		/// </summary>
		public decimal Size { get; set; }



		/// <summary>
		/// Extension
		/// </summary>
		public decimal Extension { get; set; }



		/// <summary>
		/// CategoryId
		/// </summary>
		public long CategoryId { get; set; }



		/// <summary>
		/// Type
		/// </summary>
		[Required(ErrorMessage="Type不能为空")]
		public int Type { get; set; }



		/// <summary>
		/// ParamId
		/// </summary>
		public long? ParamId { get; set; }



		/// <summary>
		/// Status
		/// </summary>
		public int Status { get; set; }



		/// <summary>
		/// FileLocation
		/// </summary>
		public int FileLocation { get; set; }



		/// <summary>
		/// CreationTime
		/// </summary>
		public DateTime CreationTime { get; set; }




    }
}