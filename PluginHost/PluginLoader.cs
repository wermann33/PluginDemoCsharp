using PluginBase;
using System.Reflection;

namespace PluginHost
{
    internal class PluginLoader
    {
        public static List<IOperation> LoadPlugins(string path)
        {
            var plugins = new List<IOperation>();

            if (!Directory.Exists(path))
            {
                Console.WriteLine($"Plugin directory not found. Creating directory at: {path}");
                Directory.CreateDirectory(path); 
                return plugins; // No plugins loaded, folder is empty
            }
            
            var assemblies = Directory.GetFiles(path, "*.dll");

            foreach (var assemblyPath in assemblies)
            {
                var assembly = Assembly.LoadFrom(assemblyPath);
                foreach (var type in assembly.GetTypes())
                {
                    // Basic approach: Check whether the IOperation interface is implemented

                    //if (typeof(IOperation).IsAssignableFrom(type) && !type.IsInterface)
                    //{
                    //    if (Activator.CreateInstance(type) is IOperation plugin)
                    //    {
                    //        plugins.Add(plugin);
                    //    }
                    //}

                    // Alternative approach: Attribute-based search

                    var attribute = type.GetCustomAttribute<PluginAttribute>();
                    if (attribute != null && typeof(IOperation).IsAssignableFrom(type) && !type.IsInterface)
                    {
                        if (Activator.CreateInstance(type) is IOperation plugin)
                        {
                            plugins.Add(plugin);
                            Console.WriteLine($"Loaded plugin: {attribute.Name}");
                        }
                    }
                }
            }

            return plugins;
        }
    }
}
