using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using CCode.EntityFrameworkCore.Seed;

namespace CCode.EntityFrameworkCore
{
    [DependsOn(
        typeof(CCodeCoreModule), 
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class CCodeEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<CCodeDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        CCodeDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        CCodeDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }                    
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CCodeEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
