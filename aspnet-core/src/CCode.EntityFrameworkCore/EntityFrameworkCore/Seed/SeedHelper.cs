using System;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using Abp.Dependency;
using Abp.Domain.Uow;
using Abp.EntityFrameworkCore.Uow;
using Abp.MultiTenancy;
using CCode.EntityFrameworkCore.Seed.Host;
using CCode.EntityFrameworkCore.Seed.Tenants;

namespace CCode.EntityFrameworkCore.Seed
{
    public static class SeedHelper
    {
        /// <summary>
        /// 数据库最初的数据初始化
        /// </summary>
        /// <param name="iocResolver"></param>
        public static void SeedHostDb(IIocResolver iocResolver)
        {
            WithDbContext<CCodeDbContext>(iocResolver, SeedHostDb);
        }

        public static void SeedHostDb(CCodeDbContext context)
        {
            context.SuppressAutoSetTenantId = true;

            // Host seed
            new InitialHostDbBuilder(context).Create();

            // Default tenant seed (in host database).
            new DefaultTenantBuilder(context).Create();
            new TenantRoleAndUserBuilder(context, 1).Create();
        }

        private static void WithDbContext<TDbContext>(IIocResolver iocResolver, Action<TDbContext> contextAction)
            where TDbContext : DbContext
        {
            using (var uowManager = iocResolver.ResolveAsDisposable<IUnitOfWorkManager>())
            {
                using (var uow = uowManager.Object.Begin(TransactionScopeOption.Suppress))
                {
                    var context = uowManager.Object.Current.GetDbContext<TDbContext>(MultiTenancySides.Host);

                    contextAction(context);

                    uow.Complete();
                }
            }
        }
    }
}
