using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Extensions.DependencyModel;

namespace AbcBlog.Shared.Extensions
{
    public static class TypeLookupExtension
    {
        public static IEnumerable<TypeInfo> ResolveModularGenericTypes(this string patterns, Type genericInterfaceType,
            Type genericType)
        {
            var assemblies = patterns
                .LoadAssemblyWithPattern()
                .SelectMany(m => m.DefinedTypes);

            var interfaceWithType = genericInterfaceType.MakeGenericType(genericType);

            return assemblies.Where(x => x.GetInterfaces().Contains(interfaceWithType));
        }

        public static IEnumerable<TypeInfo> ResolveModularTypes(this string patterns, Type interfaceType)
        {
            var assemblies = patterns
                .LoadAssemblyWithPattern()
                .SelectMany(m => m.DefinedTypes);

            return assemblies.Where(x =>
                interfaceType.IsAssignableFrom(x) &&
                !x.GetTypeInfo().IsAbstract);
        }

        public static IEnumerable<Assembly> LoadFullAssemblies(this string searchPattern)
        {
            var coreAssemblies = "AbcBlog.*".LoadAssemblyWithPattern();
            var extendAssemblies = searchPattern.LoadAssemblyWithPattern();
            return new HashSet<Assembly>(
                    extendAssemblies.SelectMany(x => coreAssemblies.Append(x)))
                .ToList();
        }

        public static IEnumerable<Assembly> LoadAssemblyWithPattern(this string searchPattern)
        {
            var assemblies = new HashSet<Assembly>();
            var searchRegex = new Regex(searchPattern, RegexOptions.IgnoreCase);
            var moduleAssemblyFiles = DependencyContext
                .Default
                .RuntimeLibraries
                .Where(x => searchRegex.IsMatch(x.Name))
                .ToList();

            foreach (var assemblyFiles in moduleAssemblyFiles)
                assemblies.Add(Assembly.Load(new AssemblyName(assemblyFiles.Name)));

            return assemblies.ToList();
        }
    }
}
