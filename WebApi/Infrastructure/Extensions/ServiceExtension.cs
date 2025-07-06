using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;

namespace WebApi.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CarBookContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("WebApi"));
                options.EnableSensitiveDataLogging();
            });
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
                options.AppendTrailingSlash = true;

            });
        }
        public static void ConfigureCustomServices(this IServiceCollection services)
        {
            // DbContext registration (already handled in ConfigureDbContext)
            services.AddScoped<CarBookContext, CarBookContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // CQRS Handlers registration
            //About Handlers
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<CreateAboutCommendsHandler>();
            services.AddScoped<UpdateAboutCommendsHandler>();
            services.AddScoped<RemoveAboutCommendsHandler>();
            // Banner Handlers
            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<CreateBannerCommendsHandler>();
            services.AddScoped<UpdateBannerCommendsHandler>();
            services.AddScoped<RemoveBannerCommendsHandler>();
            // Brand Handlers
            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<CreateBrandCommendsHandler>();
            services.AddScoped<UpdateBrandCommendsHandler>();
            services.AddScoped<RemoveBrandCommendsHandler>();
        }

    }
}
