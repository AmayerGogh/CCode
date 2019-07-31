
using AutoMapper;
using CCode.Categories;
using CCode.Categories.Dtos;

namespace CCode.Categories.Mapper
{

	/// <summary>
    /// 配置Category的AutoMapper
    /// </summary>
	internal static class CategoryMapper
    {
        public static void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap <Category,CategoryListDto>();
            configuration.CreateMap <CategoryListDto,Category>();

            configuration.CreateMap <CategoryEditDto,Category>();
            configuration.CreateMap <Category,CategoryEditDto>();

        }
	}
}
