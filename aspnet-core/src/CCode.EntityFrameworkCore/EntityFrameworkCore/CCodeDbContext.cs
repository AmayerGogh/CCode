using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CCode.Authorization.Roles;
using CCode.Authorization.Users;
using CCode.MultiTenancy;
using Microsoft.Extensions.Logging;
using System;
using CCode.Logs;

namespace CCode.EntityFrameworkCore
{
    public class CCodeDbContext : AbpZeroDbContext<Tenant, Role, User, CCodeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CCodeDbContext(DbContextOptions<CCodeDbContext> options)
            : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sql执行日志
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

    }
    public class EFLoggerProvider : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName) => new EFLogger(categoryName);
        public void Dispose() { }
    }
    public class EFLogger : ILogger
    {
        private readonly string categoryName;

        public EFLogger(string categoryName) => this.categoryName = categoryName;

        public bool IsEnabled(LogLevel logLevel) => true;

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            //ef core执行数据库查询时的categoryName为Microsoft.EntityFrameworkCore.Database.Command,日志级别为Information           
            //_value1 为参数
            //_value5 为sql
            if (categoryName == "Microsoft.EntityFrameworkCore.Database.Command" && logLevel == LogLevel.Information)
            {
                var logContent = formatter(state, exception);                
                LogManager.SqlExcute.Info(logContent);              
            }
        }

        public IDisposable BeginScope<TState>(TState state) => null;
    }

}
