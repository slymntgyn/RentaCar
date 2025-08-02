using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Interfaces;
using Application.Interfaces.CarInterfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories;
using Persistence.Repositories.CarRepositories;

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
            services.AddScoped(typeof(ICarRepository), typeof(CarRepository));


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

            // Car Handlers
            services.AddScoped<CreateCarCommandsHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<RemoveCarCommendsHandler>();
            services.AddScoped<UpdateCarCommendsHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();

            //Category Handlers
            services.AddScoped<CreateCategoryCommandsHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<RemoveCategoryCommendsHandler>();
            services.AddScoped<UpdateCategoryCommendsHandler>();

            //Contact Handlers
            services.AddScoped<CreateContactCommandsHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<RemoveContactCommandsHandler>();
            services.AddScoped<UpdateContactCommandsHandler>();

            //add mediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(service).Assembly));


        }

    }
}
