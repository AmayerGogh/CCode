using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CCode.Authorization.Roles;
using CCode.Authorization.Users;
using CCode.MultiTenancy;

namespace CCode.EntityFrameworkCore
{
    public class CCodeDbContext : AbpZeroDbContext<Tenant, Role, User, CCodeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CCodeDbContext(DbContextOptions<CCodeDbContext> options)
            : base(options)
        {
        }
    }
}
