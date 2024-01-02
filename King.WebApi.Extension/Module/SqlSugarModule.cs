using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;

namespace King.WebApi.Extension.Module
{
    public static class SqlSugarModule
    {
        /// <summary>
        /// 添加SqlSugar模块
        /// </summary>
        /// <param name="services"></param>
        public static void AddSqlSugarModule(this IServiceCollection services)
        {
            IConfiguration build = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();

            services.AddSingleton<ISqlSugarClient>(s =>
            {
                SqlSugarScope sqlSugar = new(new ConnectionConfig
                {
                    DbType = DbType.SqlServer,
                    ConnectionString = build["SqlConnection:ConnectionString"],
                    IsAutoCloseConnection = true,
                });
                return sqlSugar;
            });
        }
    }
}