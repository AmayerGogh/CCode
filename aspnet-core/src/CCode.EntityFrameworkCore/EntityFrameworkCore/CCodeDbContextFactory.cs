using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CCode.Configuration;
using CCode.Web;

namespace CCode.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CCodeDbContextFactory : IDesignTimeDbContextFactory<CCodeDbContext>
    {
        public CCodeDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CCodeDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CCodeDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CCodeConsts.ConnectionStringName));

            return new CCodeDbContext(builder.Options);
        }
    }
}
