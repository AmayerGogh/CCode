using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CCode.Authorization;

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
