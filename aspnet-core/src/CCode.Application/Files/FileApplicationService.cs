
using System;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Abp.UI;
using Abp.AutoMapper;
using Abp.Extensions;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Application.Services.Dto;
using Abp.Linq.Extensions;


using CCode.Files;
using CCode.Files.Dtos;
using CCode.Files.DomainService;
using CCode.Files.Authorization;


namespace CCode.Files
{
    /// <summary>
    /// File应用层服务的接口实现方法  
    ///</summary>
    [AbpAuthorize]
    public class FileAppService : CCodeAppServiceBase, IFileAppService
    {
        private readonly IRepository<File, long> _entityRepository;

        private readonly IFileManager _entityManager;

        /// <summary>
        /// 构造函数 
        ///</summary>
        public FileAppService(
        IRepository<File, long> entityRepository
        ,IFileManager entityManager
        )
        {
            _entityRepository = entityRepository; 
             _entityManager=entityManager;
        }


        /// <summary>
        /// 获取File的分页列表信息
        ///</summary>
        /// <param name="input"></param>
        /// <returns></returns>
		[AbpAuthorize(FilePermissions.Query)] 
        public async Task<PagedResultDto<FileListDto>> GetPaged(GetFilesInput input)
		{

		    var query = _entityRepository.GetAll();
			// TODO:根据传入的参数添加过滤条件
            

			var count = await query.CountAsync();

			var entityList = await query
					.OrderBy(input.Sorting).AsNoTracking()
					.PageBy(input)
					.ToListAsync();

			// var entityListDtos = ObjectMapper.Map<List<FileListDto>>(entityList);
			var entityListDtos =entityList.MapTo<List<FileListDto>>();

			return new PagedResultDto<FileListDto>(count,entityListDtos);
		}


		/// <summary>
		/// 通过指定id获取FileListDto信息
		/// </summary>
		[AbpAuthorize(FilePermissions.Query)] 
		public async Task<FileListDto> GetById(EntityDto<long> input)
		{
			var entity = await _entityRepository.GetAsync(input.Id);

		    return entity.MapTo<FileListDto>();
		}

		/// <summary>
		/// 获取编辑 File
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(FilePermissions.Create,FilePermissions.Edit)]
		public async Task<GetFileForEditOutput> GetForEdit(NullableIdDto<long> input)
		{
			var output = new GetFileForEditOutput();
FileEditDto editDto;

			if (input.Id.HasValue)
			{
				var entity = await _entityRepository.GetAsync(input.Id.Value);

				editDto = entity.MapTo<FileEditDto>();

				//fileEditDto = ObjectMapper.Map<List<fileEditDto>>(entity);
			}
			else
			{
				editDto = new FileEditDto();
			}

			output.File = editDto;
			return output;
		}


		/// <summary>
		/// 添加或者修改File的公共方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(FilePermissions.Create,FilePermissions.Edit)]
		public async Task CreateOrUpdate(CreateOrUpdateFileInput input)
		{

			if (input.File.Id.HasValue)
			{
				await Update(input.File);
			}
			else
			{
				await Create(input.File);
			}
		}


		/// <summary>
		/// 新增File
		/// </summary>
		[AbpAuthorize(FilePermissions.Create)]
		protected virtual async Task<FileEditDto> Create(FileEditDto input)
		{
			//TODO:新增前的逻辑判断，是否允许新增

            // var entity = ObjectMapper.Map <File>(input);
            var entity=input.MapTo<File>();
			

			entity = await _entityRepository.InsertAsync(entity);
			return entity.MapTo<FileEditDto>();
		}

		/// <summary>
		/// 编辑File
		/// </summary>
		[AbpAuthorize(FilePermissions.Edit)]
		protected virtual async Task Update(FileEditDto input)
		{
			//TODO:更新前的逻辑判断，是否允许更新

			var entity = await _entityRepository.GetAsync(input.Id.Value);
			input.MapTo(entity);

			// ObjectMapper.Map(input, entity);
		    await _entityRepository.UpdateAsync(entity);
		}



		/// <summary>
		/// 删除File信息的方法
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		[AbpAuthorize(FilePermissions.Delete)]
		public async Task Delete(EntityDto<long> input)
		{
			//TODO:删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(input.Id);
		}



		/// <summary>
		/// 批量删除File的方法
		/// </summary>
		[AbpAuthorize(FilePermissions.BatchDelete)]
		public async Task BatchDelete(List<long> input)
		{
			// TODO:批量删除前的逻辑判断，是否允许删除
			await _entityRepository.DeleteAsync(s => input.Contains(s.Id));
		}


		/// <summary>
		/// 导出File为excel表,等待开发。
		/// </summary>
		/// <returns></returns>
		//public async Task<FileDto> GetToExcel()
		//{
		//	var users = await UserManager.Users.ToListAsync();
		//	var userListDtos = ObjectMapper.Map<List<UserListDto>>(users);
		//	await FillRoleNames(userListDtos);
		//	return _userListExcelExporter.ExportToFile(userListDtos);
		//}

    }
}


