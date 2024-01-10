using LexiconLMS.Domain.Entities;
using LexiconLMS.Server.Repositories;
using LexiconLMS.Server.Services;
using Microsoft.Extensions.DependencyInjection;

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

            services.AddScoped<IActivityRepository, ActivityRepository>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped(provider => new Lazy<IActivityRepository>(() => provider.GetRequiredService<IActivityRepository>()));
            services.AddScoped(provider => new Lazy<IActivityService>(() => provider.GetRequiredService<IActivityService>()));

            services.AddScoped<IModuleRepository, ModuleRepository>();
            services.AddScoped<IModuleService, ModuleService>();
            services.AddScoped(provider => new Lazy<IModuleRepository>(() => provider.GetRequiredService<IModuleRepository>()));
            services.AddScoped(provider => new Lazy<IModuleService>(() => provider.GetRequiredService<IModuleService>()));

            services.AddScoped<IActivityTypeRepository, ActivityTypeRepository>();
            services.AddScoped<IActivityTypeService, ActivityTypeService>();
            services.AddScoped(provider => new Lazy<IActivityTypeRepository>(() => provider.GetRequiredService<IActivityTypeRepository>()));
            services.AddScoped(provider => new Lazy<IActivityTypeService>(() => provider.GetRequiredService<IActivityTypeService>()));

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
