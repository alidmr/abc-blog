using AbcBlog.Domain.Interfaces.Articles;
using AbcBlog.Domain.Interfaces.Users;
using AbcBlog.Domain.Proxies;
using AbcBlog.Infrastructure.Context;
using AbcBlog.Infrastructure.Extensions;
using AbcBlog.Infrastructure.Proxies;
using AbcBlog.Infrastructure.Repository.Articles;
using AbcBlog.Infrastructure.Repository.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AbcBlog.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AbcBlogContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();

            services.AddScoped<ITokenProxy, TokenProxy>();

            var registeredAssemblies = configuration.LoadFullAssemblies();

            services.AddMediatR(registeredAssemblies.ToArray());


            return services;
        }
    }
}
