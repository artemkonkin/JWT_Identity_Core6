using AppDbContext;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace JWT_Identity_Core6.Extensions
{
    /// <summary>
    /// Расширение сервисных функций
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Настройка соединения с базой данных
        /// </summary>
        /// <param name="services"> Коллекция сервисов </param>
        /// <param name="configuration"> Конфигуратор </param>
        /// <returns></returns>
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var conStrBuilder = new SqlConnectionStringBuilder(configuration.GetConnectionString("DbConnectionString"));
            var connection = conStrBuilder.ConnectionString;

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connection);
            }
            );

            services.AddScoped<Func<ApplicationDbContext>>((provider) => ()
                => provider.GetService<ApplicationDbContext>()
                   ?? throw new InvalidOperationException());

            return services;
        }

        /// <summary>
        /// Добавление репозиториев
        /// </summary>
        /// <param name="services"> Коллекция сервисов </param>
        /// <returns></returns>
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services;
        }

        /// <summary>
        /// Добавить сервисы
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services;
        }
    }
}
