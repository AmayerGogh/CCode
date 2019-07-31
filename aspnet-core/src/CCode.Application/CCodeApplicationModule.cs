using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CCode.Authorization;
using CCode.Blogs.Authorization;
using CCode.Blogs.Mapper;
using CCode.Categories.Authorization;
using CCode.Categories.Mapper;
using CCode.Files.Authorization;
using CCode.Files.Mapper;

namespace CCode
{
    [DependsOn(
        typeof(CCodeCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class CCodeApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CCodeAuthorizationProvider>();

            Configuration.Authorization.Providers.Add<ArticleAppAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<CategoryAuthorizationProvider>();
            Configuration.Authorization.Providers.Add<FileAuthorizationProvider>();


            Configuration.Modules.AbpAutoMapper().Configurators.Add(configuration =>
            {             
                CategoryMapper.CreateMappings(configuration);
                FileMapper.CreateMappings(configuration);
                ArticleDtoMapper.CreateMappings(configuration);
                // ....
            });
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CCodeApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
