using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CCode.EntityFrameworkCore
{
    public static class CCodeDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CCodeDbContext> builder, string connectionString)
        {
            //builder.UseSqlServer(connectionString);
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CCodeDbContext> builder, DbConnection connection)
        {           
            //builder.UseSqlServer(connection);
            builder.UseMySql(connection);
        }
    }
}
