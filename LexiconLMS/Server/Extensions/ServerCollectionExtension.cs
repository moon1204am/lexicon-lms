using LexiconLMS.Server.Repositories;
using LexiconLMS.Server.Services;

namespace LexiconLMS.Server.Extensions
{
    public static class ServerCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped(provider => new Lazy<ICourseRepository>(() => provider.GetRequiredService<ICourseRepository>()));
            services.AddScoped(provider => new Lazy<ICourseService>(() => provider.GetRequiredService<ICourseService>()));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped(provider => new Lazy<IUserRepository>(() => provider.GetRequiredService<IUserRepository>()));
            services.AddScoped(provider => new Lazy<IUserService>(() => provider.GetRequiredService<IUserService>()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServiceManager, ServiceManager>();
        }

        public static void AddCorsPolicy(this IServiceCollection services) =>
            services.AddCors(opt =>
            {
                opt.AddPolicy(ApiConstants.policyName, builder =>
                {
                    builder.WithOrigins("https://localhost:7190")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
    }
}
