using System.Reflection;
using AbcBlog.Shared.Exceptions;
using AbcBlog.Shared.Extensions;
using Microsoft.Extensions.Configuration;

namespace AbcBlog.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static IEnumerable<Assembly> LoadFullAssemblies(this IConfiguration configuration)
        {
            var assemblyPattern = configuration["AssemblyPattern"];
            if (string.IsNullOrEmpty(assemblyPattern))
            {
                throw new CoreException("Add AssemblyPattern key in appsettings.json for automatically loading assembly");
            }

            return assemblyPattern.LoadFullAssemblies();
        }
    }
}
