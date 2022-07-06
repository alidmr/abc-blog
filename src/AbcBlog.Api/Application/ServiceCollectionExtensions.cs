using AbcBlog.Api.Application.Behaviors;
using AbcBlog.Api.Application.Middlewares;
using AbcBlog.Infrastructure.Extensions;
using FluentValidation;
using MediatR;

namespace AbcBlog.Api.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ExceptionHandlingMiddleware>();
            //services.AddMediatR(typeof(CreateUserCommand).GetTypeInfo().Assembly);

            var registeredAssemblies = configuration.LoadFullAssemblies();

            //services.AddValidatorsFromAssembly(assembly);

            services.AddValidatorsFromAssemblies(registeredAssemblies.ToArray());

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}
