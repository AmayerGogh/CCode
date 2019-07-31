
using AutoMapper;
using CCode.Files;
using CCode.Files.Dtos;

namespace CCode.Files.Mapper
{

	/// <summary>
    /// 配置File的AutoMapper
    /// </summary>
	internal static class FileMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <File,FileListDto>();
            configuration.CreateMap <FileListDto,File>();

            configuration.CreateMap <FileEditDto,File>();
            configuration.CreateMap <File,FileEditDto>();

        }
	}
}
