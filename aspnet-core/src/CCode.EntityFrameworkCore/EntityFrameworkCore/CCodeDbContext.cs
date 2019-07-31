using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using CCode.Authorization.Roles;
using CCode.Authorization.Users;
using CCode.MultiTenancy;
using Microsoft.Extensions.Logging;
using System;
using CCode.Logs;
using CCode.Blogs;
using CCode.Categories;
using CCode.EntityMapper.Categories;
using CCode.EntityMapper.Files;
using CCode.Files;

namespace CCode.EntityFrameworkCore
{
    public class CCodeDbContext : AbpZeroDbContext<Tenant, Role, User, CCodeDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public CCodeDbContext(DbContextOptions<CCodeDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleDetail> ArticleDetails { get; set; }
        public virtual DbSet<ArticleLabel> ArticleLabels { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<File> Files { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //sql执行日志
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new EFLoggerProvider());
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryCfg());
            modelBuilder.ApplyConfiguration(new FileCfg());
            base.OnModelCreating(modelBuilder);
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
